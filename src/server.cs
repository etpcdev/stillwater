$Prefs::Server::StillWater = 0;
package stillwater
{
	function checkForWaterZone(){
		if(isObject(WaterZone)){
			return WaterZone;
		}
		else
		{
			%client.chatmessage("\c6No water to change!");
			return;
		}
	}
	function serverCmdStillWater(%client, %message)
	{
		if(!%client.isSuperAdmin)
		{
			%client.chatmessage("\c6Ask a Super Admin to toggle still water!");
			return;
		}

		%wz = checkForWaterZone();
		if(!isObject(%wz))
		{
			$Prefs::Server::StillWater = 0;
			%client.chatmessage("\c6No water to change!");
			return;
		}

		if($Prefs::Server::StillWater == 0)
		{
			%wz.waterDensity = 0;
			%wz.gravityMod = 0;
			$Prefs::Server::StillWater = 1;
			%client.chatmessage("\c6Still water \c5enabled\c6.");
		}
		else
		{
			%wz.waterDensity = 1;
			%wz.gravityMod = 1;
			$Prefs::Server::StillWater = 0;
			%client.chatmessage("\c6Still water \c4disabled\c6.");
		}
		return;
	}

	function GameConnection::AutoAdminCheck(%client)
	{
		%client.chatmessage("\c6This server uses Still Water! Type /stillWater to toggle buoyancy on or off.");
		return Parent::AutoAdminCheck(%client);
	}
};

activatePackage(stillwater);
