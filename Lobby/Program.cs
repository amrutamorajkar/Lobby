using Lobby;

string input = "<td onclick=''></td><script>alert('I am a hacker http://foo')</script>";
string[] matchTags = new string[] {  "onclick" };
bool matchScriptTag = true;

Console.WriteLine("Output is :{0}", input.SanitizeHTML(matchScriptTag, matchTags));