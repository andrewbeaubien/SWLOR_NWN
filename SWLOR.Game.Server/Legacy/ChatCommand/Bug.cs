﻿using System;
using SWLOR.Game.Server.Legacy.ChatCommand.Contracts;
using SWLOR.Game.Server.Legacy.Data.Entity;
using SWLOR.Game.Server.Legacy.Enumeration;
using SWLOR.Game.Server.Legacy.GameObject;
using SWLOR.Game.Server.Legacy.Service;
using SWLOR.Game.Server.Legacy.ValueObject;
using static SWLOR.Game.Server.Core.NWScript.NWScript;

namespace SWLOR.Game.Server.Legacy.ChatCommand
{
    [CommandDetails("Report a bug to the developers. Please include as much detail as possible.", CommandPermissionType.Player | CommandPermissionType.DM | CommandPermissionType.Admin)]
    public class Bug : IChatCommand
    {
        public void DoAction(NWPlayer user, NWObject target, NWLocation targetLocation, params string[] args)
        {
            var message = string.Empty;

            foreach (var arg in args)
            {
                message += " " + arg;
            }

            if(message.Length > 1000)
            {
                user.SendMessage("Your message was too long. Please shorten it to no longer than 1000 characters and resubmit the bug. For reference, your message was: \"" + message + "\"");
                return;
            }

            var position = GetPositionFromLocation(user.Location);
            var orientation = GetFacingFromLocation(user.Location);
            var report = new BugReport
            {
                SenderPlayerID = user.IsPlayer ? new Guid?(user.GlobalID): null,
                CDKey = GetPCPublicCDKey(user),
                Text = message,
                TargetName = target.IsValid ? target.Name : user.Name,
                AreaResref = GetResRef(user.Area),
                SenderLocationX = position.X,
                SenderLocationY = position.Y,
                SenderLocationZ = position.Z,
                SenderLocationOrientation = orientation,
                DateSubmitted = DateTime.UtcNow
            };

            // Bypass the cache and save directly to the DB.
            DataService.DataQueue.Enqueue(new DatabaseAction(report, DatabaseActionType.Insert));

            user.SendMessage("Bug report submitted! Thank you for your report.");
        }

        public string ValidateArguments(NWPlayer user, params string[] args)
        {
            if (args.Length <= 0 || args[0].Length <= 0)
            {
                return "Please enter in a description for the bug.";
            }

            return string.Empty;
        }

        public bool RequiresTarget => false;
    }
}