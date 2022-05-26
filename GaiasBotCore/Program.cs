using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace GaiasBotCore
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            DiscordSocketConfig _config = new DiscordSocketConfig
            { //?
                HandlerTimeout = 2000,
                AlwaysDownloadUsers = true
            };

            Bot._client = new DiscordSocketClient(_config);

            Bot._client.Log += Bot.Log;
            Bot._client.MessageReceived += Bot.OnMessageReceived;
            Bot._client.UserJoined += Bot.OnUserJoined;
            Bot._client.UserLeft += Bot.OnUserLeft;
            Bot._client.ReactionAdded += Bot.OnReactionAdded;

            await Bot._client.SetGameAsync("say !sendhelp");
            await Bot._client.LoginAsync(TokenType.Bot, Bot.Token);
            await Bot._client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);

        }
    }
}
