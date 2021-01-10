using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sorea_Stefania_Proiect.Data;

namespace Sorea_Stefania_Proiect.Models
{
    public class RolePageModel:PageModel
    {
        public List<AssignedVoiceActorData> AssignedRoleDataList;
        public void PopulateAssignedRoleData(Sorea_Stefania_ProiectContext context, Character character)
        {
            var allVoiceActors = context.VoiceActor;
            var roles = new HashSet<int>(
                character.Roles.Select(c => c.CharacterID));
            AssignedRoleDataList = new List<AssignedVoiceActorData>();
            foreach (var va in allVoiceActors)
            {
                AssignedRoleDataList.Add(new AssignedVoiceActorData{
                    VoiceActorID=va.ID, 
                    Name=va.Name, 
                    Assigned=roles.Contains(va.ID)
                });
            }
        }

        public void UpdateRoles(Sorea_Stefania_ProiectContext context, string[] selectedVoiceActors, Character characterToUpdate)
        {
            if (selectedVoiceActors == null)
            {
                characterToUpdate.Roles = new List<Role>();
                return;
            }
            var selectedVoiceActorsHS = new HashSet<string>(selectedVoiceActors);
            var roles = new HashSet<int>(characterToUpdate.Roles.Select(c => c.VoiceActor.ID));
            foreach(var va in context.VoiceActor)
            {
                if (selectedVoiceActorsHS.Contains(va.ID.ToString()))
                {
                    if (!roles.Contains(va.ID))
                    {
                        characterToUpdate.Roles.Add(new Role
                        {
                            CharacterID = characterToUpdate.ID,
                            VoiceActorID=va.ID
                        });
                    }
                }
                else
                {
                    if (roles.Contains(va.ID))
                    {
                        Role courseToRemove = characterToUpdate.Roles.SingleOrDefault(i => i.VoiceActorID == va.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
