using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlfipCombatGame.AlfipCore;
using static AlfipCombatGame.Dice;

namespace AlfipCombatGame
{
    internal static class ACPreset
    {
        static ACPreset()
        {
            DefDatabase.Add( new CharacterDef() 
                { 
                    defName = "Character_Alfip",
                    label = "Alfip",
                    characterName = "亚尔菲普",
                    defaultStat = new CharacterStatSet(
                        ATK: 15,
                        HP:5,
                        DEF:2,
                        MOV:3,
                        SPD:5
                        ),
                    defaultLoadout = new LoadoutSet() { 
                    
                    },
                });;
        }
    }
}
