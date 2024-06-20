#t

Invoke-RestMethod -Uri "https://localhost:7106/add-member" -Method Put -Headers @{ "Content-Type" = "application/json" } -Body (ConvertTo-Json @{ HouseOfLordsId = 9999; NameFullTitle = "Test"; Gender = "M"; PartyId = 9999; MembershipStatusIsActive = $true; MembershipStartDate = "2019-12-12T00:00:00"; MembershipEndDate = "2024-05-30T00:00:00"; MembershipEndReason = "Test"; MemberFrom = "Test"; ImageUrl = "Test"; }) 



