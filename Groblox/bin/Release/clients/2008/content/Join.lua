-- Attempt to load avatar script safely
pcall(function() dofile("rbxasset://avatar.lua") end)

-- CONFIGURATION
local server     = _G.server or "127.0.0.1"
local serverport = tonumber(_G.port) or 53640
local playername = _G.name or "Player"

local playerid = tonumber(_G.id)
if not playerid then
    math.randomseed(tick() * 1000)
    playerid = math.random(1000, 9999)
end

local clientport = 0

----------------------------------------------------------------
-- ERROR HANDLER
----------------------------------------------------------------
local function dieerror(errmsg)
    game:SetMessage("[ERROR] " .. tostring(errmsg))
--    while true do wait(1) end
end

----------------------------------------------------------------
-- CLIENT & PLAYER INITIALIZATION
----------------------------------------------------------------
local suc, err = pcall(function()
    client = game:GetService("NetworkClient")
    player = game:GetService("Players"):CreateLocalPlayer(0)
    player:SetSuperSafeChat(false)
    game:GetService("Visit") -- initialize visit service
end)
if not suc then dieerror(err) end

----------------------------------------------------------------
-- CONNECTION HANDLERS
----------------------------------------------------------------
local replicator  -- active replicator reference

local function connected(url, repl)
    replicator = repl

    -- initial marker
    pcall(function()
        if replicator then
            replicator:SendMarker()
        end
    end)

    -- safe Recieved hook
    if replicator and replicator.Recieved then
        replicator.Recieved:connect(function(msg)
            pcall(function()
                -- optionally process message
                game:ClearMessage()
            end)
        end)
    else
        pcall(function()
            game:ClearMessage()
        end)
    end
end

local function rejected()
    dieerror("Connection rejected by server.")
end

local function failed(peer, errcode, why)
    dieerror("Failed [".. tostring(peer) .."], ".. tostring(errcode) .. ": ".. tostring(why))
end

----------------------------------------------------------------
-- CONNECT CLIENT
----------------------------------------------------------------
local suc, err = pcall(function()
    client.ConnectionAccepted:connect(connected)
    client.ConnectionRejected:connect(rejected)
    client.ConnectionFailed:connect(failed)

    client:Connect(server, serverport, clientport, 20)

    player.Name = playername
    player.userId = playerid

end)
if not suc then dieerror(err) end

----------------------------------------------------------------
-- BACKGROUND MARKER LOOP
----------------------------------------------------------------
-- using coroutine for legacy compatibility
local markerThread = coroutine.create(function()
    while true do
        wait(0.05)
        if replicator then
            pcall(function()
                replicator:SendMarker()
            end)
        end
    end
end)
coroutine.resume(markerThread)

----------------------------------------------------------------
-- OPTIONAL MODS / CUSTOM HOOKS
----------------------------------------------------------------
-- Example: auto join chat, join MOTD, auto-respawn
pcall(function()
    -- auto respawn character
    player.CharacterAdded:connect(function(char)
        -- optionally position or setup character
        print("Character spawned for " .. player.Name)
    end)

end)
