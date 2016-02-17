# Instant Lead Alerts for C# and ASP.NET MVC

This demo application shows how to implement instant lead alerts using C# and ASP.NET MVC. Notify sales reps or agents right away when a new lead comes in for a real estate listing or other high value channel.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/lead-alerts/csharp/mvc)!

[![Build status](https://ci.appveyor.com/api/projects/status/7b6v4xetbn0uy6yc/branch/master?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/lead-alerts-csharp/branch/master)

## Local Development

1. Clone this repository and `cd` into its directory:
   ```
   git clone git@github.com:TwilioDevEd/lead-alerts-csharp.git
   cd lead-alerts-csharp
   ```

1. Create a new file `LeadAlerts.Web/Local.config` and update the content with:
   ```
   <appSettings>
     <add key="TwilioAccountSid" value="Your Twilio Account SID" />
     <add key="TwilioAuthToken" value="Your Twilio Auth Token" />
     <add key="TwilioPhoneNumber" value="Your Twilio Phone Number" />
     <add key="AgentPhoneNumber" value="Agent Phone Number" />
   </appSettings>
   ```

1. Build the solution.

1. Run the application.

1. Check it out at [http://localhost:3000](http://localhost:3000)

That's it!

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
