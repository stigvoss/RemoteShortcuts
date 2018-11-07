using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using RemoteShortcuts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RemoteShortcuts.Client.Pages.CodeBehinds
{
    public class ShortcutsBase : BlazorComponent
    {
        public ShortcutsBase()
        {
            Shortcuts = new List<Shortcut>();
        }

        [Inject]
        public HttpClient Http { get; set; }

        public IEnumerable<Shortcut> Shortcuts { get; set; }

        protected override async Task OnInitAsync()
        {
            Shortcuts = await Http.GetJsonAsync<Shortcut[]>("api/Shortcuts");
        }
    }
}
