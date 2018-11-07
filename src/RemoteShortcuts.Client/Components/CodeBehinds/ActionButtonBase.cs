using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using RemoteShortcuts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemoteShortcuts.Client.Components.CodeBehinds
{
    public class ActionButtonBase : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }

        [Parameter]
        protected Shortcut Shortcut { get; set; }

        public string Text => Shortcut?.Name;

        public async Task RunAction()
        {
            var serializedShortcut = Json.Serialize(Shortcut);
            var content = new StringContent(serializedShortcut, Encoding.UTF8, "application/json");

            await Http.PutAsync("api/Shortcuts", content);
        }

    }
}
