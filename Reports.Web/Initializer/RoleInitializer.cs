using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Reports.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Web.Initializer
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            #region Data

            string adminUserEmail = "admin@gmail.com";
            string firstUserEmail = "first@gmail.com";
            string secondUserEmail = "second@gmail.com";
            string bothUserEmail = "both@gmail.com";

            string password = "_Aa123456";

            #endregion

            #region Creating roles

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("first") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("first"));
            }

            if (await roleManager.FindByNameAsync("second") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("second"));
            }

            #endregion

            #region Creating users

            if (await userManager.FindByNameAsync(adminUserEmail) == null)
            {
                IdentityUser admin = new IdentityUser { Email = adminUserEmail, UserName = adminUserEmail };

                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            if (await userManager.FindByNameAsync(firstUserEmail) == null)
            {
                IdentityUser firstUser = new IdentityUser { Email = firstUserEmail, UserName = firstUserEmail };

                IdentityResult result = await userManager.CreateAsync(firstUser, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(firstUser, "first");
                }
            }

            if (await userManager.FindByNameAsync(secondUserEmail) == null)
            {
                IdentityUser secondUser = new IdentityUser { Email = secondUserEmail, UserName = secondUserEmail };

                IdentityResult result = await userManager.CreateAsync(secondUser, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(secondUser, "second");
                }
            }

            if (await userManager.FindByNameAsync(bothUserEmail) == null)
            {
                IdentityUser bothUser = new IdentityUser { Email = bothUserEmail, UserName = bothUserEmail };

                IdentityResult result = await userManager.CreateAsync(bothUser, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(bothUser, "first");
                    await userManager.AddToRoleAsync(bothUser, "second");
                }
            }

            #endregion
        }
    }
}
