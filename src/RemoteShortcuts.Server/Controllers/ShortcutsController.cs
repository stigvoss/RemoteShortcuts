using RemoteShortcuts.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsInput;
using RemoteShortcuts.Server.Models;

namespace RemoteShortcuts.Server.Controllers
{
    [Route("api/[controller]")]
    public class ShortcutsController : Controller
    {
        private readonly Shortcut[] _shortcuts = new Shortcut[]
            {
                new Shortcut
                {
                    Id = new Guid("{0894B6AD-D668-470E-9F48-0EFDE8828B56}"),
                    Name = "Format Code",
                    Command = (target) =>
                    {
                        target.Press("CONTROL", "VK_E");
                        target.Press("VK_D");
                    }
                },
                new Shortcut
                {
                    Id = new Guid("{9ED44BAA-E8F4-423A-A16A-B57570070869}"),
                    Name = "Build",
                    Command = (target) =>
                    {
                        target.Press("F6");
                    }
                },
                new Shortcut
                {
                    Id = new Guid("{A812ECAC-43B2-4298-87D7-9CF84AC3BA84}"),
                    Name = "Debug",
                    Command = (target) =>
                    {
                        target.Press("F5");
                    }
                },
                new Shortcut
                {
                    Id = new Guid("{2F93FCC4-CBDA-4035-8E35-C615F43A4C1C}"),
                    Name = "Comment",
                    Command = (target) =>
                    {
                        target.Press("CONTROL", "VK_E");
                        target.Press("VK_C");
                    }
                },
                new Shortcut
                {
                    Id = new Guid("{2976A8FD-C690-426B-B3D5-8607C1B91A74}"),
                    Name = "Uncomment",
                    Command = (target) =>
                    {
                        target.Press("CONTROL", "VK_E");
                        target.Press("VK_U");
                    }
                },
            };

        [HttpGet]
        public ActionResult<IEnumerable<Shortcut>> Shortcuts()
        {
            return _shortcuts;
        }

        [HttpPut]
        public ActionResult Execute([FromBody]Shortcut shortcut)
        {
            var simulator = new InputSimulator();
            var keyboard = new KeyboardCommands(simulator.Keyboard);

            var executedShortcut = _shortcuts.FirstOrDefault(e => e.Id == shortcut.Id);

            if (executedShortcut is object && executedShortcut.Command is object)
            {
                executedShortcut.Command(keyboard);
            }

            return Ok();
        }
    }
}
