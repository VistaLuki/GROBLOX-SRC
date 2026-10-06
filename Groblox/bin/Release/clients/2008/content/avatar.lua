-- avatar.lua replacement
-- minimal version for patched 2009 client

local Players = game:GetService("Players")
local RunService = game:GetService("RunService")

-- Create the "Appearance" object for the local player
local function createAppearance(player)
    local appearance = Instance.new("IntValue")
    appearance.Name = "Appearance"
    appearance.Parent = player

    -- basic body colors
    local colors = {"Head Color","Torso Color","Left Arm Color","Right Arm Color","Left Leg Color","Right Leg Color"}
    for i, name in ipairs(colors) do
        local bc = Instance.new("BrickColorValue")
        bc.Name = name
        bc.Value = BrickColor.new(1) -- default white
        bc.Parent = appearance

        local index = Instance.new("NumberValue")
        index.Name = "ColorIndex"
        index.Value = i
        index.Parent = bc

        local typeval = Instance.new("NumberValue")
        typeval.Name = "CustomizationType"
        typeval.Value = 1
        typeval.Parent = bc
    end

    -- default hats/shirts/pants/face/head
    local items = {
        {Type=2, Name="Hat 1", Value="NoHat.rbxm"},
        {Type=2, Name="Hat 2", Value="NoHat.rbxm"},
        {Type=2, Name="Hat 3", Value="NoHat.rbxm"},
        {Type=3, Name="T-Shirt", Value="NoTShirt.rbxm"},
        {Type=4, Name="Shirt", Value="NoShirt.rbxm"},
        {Type=5, Name="Pants", Value="NoPants.rbxm"},
        {Type=6, Name="Face", Value="DefaultFace.rbxm"},
        {Type=7, Name="Head", Value="DefaultHead.rbxm"},
        {Type=8, Name="Extra", Value="NoExtra.rbxm"}
    }

    for _, item in pairs(items) do
        local val = Instance.new("StringValue")
        val.Name = item.Name
        val.Value = item.Value
        val.Parent = appearance

        local typeval = Instance.new("NumberValue")
        typeval.Name = "CustomizationType"
        typeval.Value = item.Type
        typeval.Parent = val
    end

    return appearance
end

-- Create a ServerReplicator for patched clients
local function createServerReplicator(player)
    local Server = game:GetService("NetworkServer")
    if not Server then return end

    local anonId = Instance.new("StringValue")
    anonId.Name = "AnonymousIdentifier"
    anonId.Value = tostring(math.random(1000,9999))
    anonId.Parent = player

    local name = "ServerReplicator|"..player.Name.."|"..player.userId.."|"..anonId.Value
    local replicator = Instance.new("Folder")
    replicator.Name = name
    replicator.Parent = Server

    return replicator
end

-- Load the character with basic parts
local function loadCharacter(player)
    player:LoadCharacter() -- Roblox default spawn
    local appearance = player:FindFirstChild("Appearance")
    if appearance and player.Character then
        -- you can expand this later to add hats, shirts, pants, face
        -- for now, humanoid + torso + head is enough
        local char = player.Character
        if not char:FindFirstChild("Head") then
            local head = Instance.new("Part")
            head.Name = "Head"
            head.Size = Vector3.new(2,1,1)
            head.Parent = char
            local hum = char:FindFirstChild("Humanoid") or Instance.new("Humanoid", char)
        end
    end
end

-- Public function to initialize avatar
function InitializeLocalPlayer(player)
    createAppearance(player)
    local replicator = createServerReplicator(player)
    loadCharacter(player)
end

-- Optional: automatically run for the first LocalPlayer
pcall(function()
    local plr = Players:GetPlayers()[1] or Players.LocalPlayer
    if plr then
        InitializeLocalPlayer(plr)
    end
end)
