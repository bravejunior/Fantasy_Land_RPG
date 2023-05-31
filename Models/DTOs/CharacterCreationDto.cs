using Models.Entities;
using Models.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CharacterCreationDto
    {
        public string CharacterName { get; set; }
        public string Gender { get; set; }
        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public bool IsSelected { get; set; } = false;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public string ClassName { get; set; }
        public string Username { get; set; }
    }
}
