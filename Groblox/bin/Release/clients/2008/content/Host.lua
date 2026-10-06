-- Minimal 2008-style host with auto character spawning
local serverport = tonumber(_G.port) or 53640

Port = serverport
Server = game:GetService("NetworkServer")
RunService = game:GetService("RunService")

-- Start server
Server:start(Port, 20)
RunService:run()
print("Server running on port " .. Port)

-- Player join handler
function onJoined(newPlayer)
    print("New connection accepted: " .. newPlayer.Name)

    -- load character using legacy engine method
    newPlayer:LoadCharacter()

    -- Respawn loop
    while true do
        wait(0.1) -- small delay to reduce CPU usage
        local char = newPlayer.Character
        if char then
            local humanoid = char:FindFirstChild("Humanoid")
            if humanoid and humanoid.Health == 0 then
                print(newPlayer.Name .. " died. Respawning...")
                wait(5)
                newPlayer:LoadCharacter()
                print(newPlayer.Name .. " respawned")
            elseif char.Parent == nil then
                -- ensure character isn't deleted
                wait(5)
                newPlayer:LoadCharacter()
            end
        end
    end
end

-- Connect player join event
game.Players.PlayerAdded:connect(onJoined)

print("Host ready. Waiting for players...")
