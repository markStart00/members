
Write-Output ""
Write-Output ""
Write-Output "		Generating ...		"
Write-Output ""

$microserviceUrl = "http://localhost:5053/current-members"
$response = Invoke-RestMethod -Uri $microserviceUrl -Method Get

$iteration = 0
$memberData = @()
$htmlImageSelection = ""
$htmlColours = ""
$sampleSize = 25
#$sampleSize =
$maleCount = 0
$femaleCount = 0
$imageCount = 0

foreach ($member in $response) {

	$customObject = [PSCustomObject] @{

		Id = $member.id

	       	HouseOfLordsId = $member.houseOfLordsId
	       	NameFullTitle = $member.nameFullTitle
	       	Gender = $member.gender
	       	PartyId = $member.partyId
		MembershipStatusIsActive = $member.membershipStatusIsActive
		MembershipStartDate = $member.membershipStartDate
		MembershipEndDate = $member.membershipEndDate
		MembershipEndReason = $member.membershipEndReason
		MemberFrom = $member.memberFrom
		ImageUrl = $member.imageUrl
		PartyName = $member.party.name
		PartyColour = $member.party.colour
       	
	}

	if ($member.gender -eq 'm') {
		$maleCount ++
	}

	if ($member.gender -eq 'f') {
		$femaleCount ++
	}

	if ($iteration % $sampleSize -eq 0) {

		$imageUrl = $member.imageUrl
		$infoValue = $member.nameFullTitle

		if ($imageCount -eq 7) {
			$imageUrl = "./mrBurns.png"
		}

		if ($imageCount -eq 20) {
			$imageUrl = "./darth.png"
		}

		$htmlImageSelection += "<img src='$imageUrl' class='portrait' style=' 
			width:100px; 
			height=100px; 
			display:inline-block; 
			margin: 5px; ' 
			alt='$infoValue'
			onmouseover='changeImage(this)'
			onmouseout='resetImage()'
			/>"

		$imageCount ++
	}

	if($member.party.colour) {
		$colour = $member.party.colour
		$htmlColours += "<div style=' 
			width:10px; 
			height:10px; 
			background-color: #$colour; 
			border: 1px solid white; 
			margin: 0px; 
			display: inline-block; '> </div>"
	}

	$memberData += $customObject
	$iteration ++

}


$totalMembers = $memberData.Count
$totalMembers = $totalMembers
$malePercent = [math]::round(( $maleCount / $totalMembers ) * 100)
$femalePercent = [math]::round(( $femaleCount / $totalMembers ) * 100)

$htmlSummaryTable = @"
<table id="members-table">
	<tr><th>Total Members </th><td> $totalMembers</td></tr>
	<tr class='no-border'><th class='no-border'></th><td class='no-border'></td></tr>
	<tr><th>Female </th><td>$femaleCount </td><td> $femalePercent %</td></tr>
	<tr><th>Male </th><td>$maleCount </td><td> $malePercent %</td></tr>
</table>
"@

$htmlMembersTable = $memberData | ConvertTo-Html -Property HouseOfLordsId, NameFullTitle, Gender, MembershipStartDate, MemberFrom, ImageUrl, PartyName, PartyColour -Fragment

$htmlFile = @"
<!DOCTYPE html>
<html>
	<head>
		<title>Report</title>
		<style>
			* {
				padding: 5px;
				margin: 5px;
				border-radius: 5px;
				border: solid 1px black;
				font: 'Arial';
			}
			.images {
				display: flex; 
				flex-wrap: wrap;
			}
			.portrait{
			}
			th ,td { 
 				padding-right: 30px;
				border: none !important
				align-items: left;
			;}
			.container {
				display: flex;
				width: 80vw;
				height: 290px;
				border: none !important
			}
			.left, .right {
 				width: 50%;
				height: 200px;
				border: none !important
			}
			#members-table {
				margin-top: 10px;
				margin-left: 10px;
				border: none !important;
				font-size: 25px;
			}
			#data-table {
				width: 94vw;
			}
			.profile {
				height: 150px;
				width: 150px;
			}
			#profile-image  {
				height: 170px;
				width: 170px;
			}
			#profile {
				height: 200px;
				width: 200px;
			}
			h3 {
				width: 500px;
			}
			.no-border {
				border: none !important;
			}
		</style>
		<script>
			function changeImage(element) {
				document.getElementById('profile').src = element.src;
				document.getElementById('info-value').textContent = element.alt;
			}

			function resetImage() {
				document.getElementById('profile').src = './default.jpg';
				document.getElementById('info-value').textContent = '';
			}
		</script>
	</head>
	<body>
		<h1>Report</h1>
		<div class="container">
		  <div class="left">
		    $htmlSummaryTable
		  </div>
		  <div id="profile-image" class="right">
		  	<img id="profile" src='./default.jpg' >	
			<h3 id='info-value'> _ </h3>
		  </div>
		</div>
		<div class="images">
			$htmlImageSelection
		</div>

		<div class="images">
			$htmlColours
		</div>
		<div id='data-table'>
			$htmlMembersTable
		</div>
	</body>
</html>
"@

$filePath = "./report.html"

$htmlFile | Out-File -FilePath $filePath


Write-Output ""
Write-Output "		Report Saved: $filePath		"
Write-Output ""
Write-Output ""
Write-Output ""




