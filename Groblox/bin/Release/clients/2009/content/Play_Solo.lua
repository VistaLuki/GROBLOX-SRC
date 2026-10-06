local plr = game.Players:CreateLocalPlayer(0)

-- Use the username supplied by the launcher
if _G.name and _G.name ~= "" then
    plr.Name = _G.name
end

game:GetService("Visit")
game:GetService("RunService"):run()
plr:LoadCharacter()

print("RBLXDev solo script - Player: " .. plr.Name)

coroutine.wrap(function()
    while true do
        wait(0.1)

        if plr.Character and plr.Character:FindFirstChild("Humanoid") then
            if plr.Character.Humanoid.Health == 0 then
                wait(5)
                plr:LoadCharacter()
                print("LocalPlayer was killed.")
            end
        end
    end
end)()