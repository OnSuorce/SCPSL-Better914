using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Better914
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Probability to become scp 049-2 in the 914 on rough setting")]
        public int roughConversionProbabilityTo492 { get; set; } = 40;

        [Description("Damage applied on rough")]
        public float roughDamage { get; set; } = 34f;

        [Description("Minimun players to spawn item on rough setting")]
        public int roughMinimunPlayers { get; set; } = 1;

        [Description("Probability to become scp don matteo")]
        public int coarseScpDMProbability { get; set; } = 30;

        [Description("Riduzione vita")]
        public int coarseHealthReductionProbability { get; set; } = 20;

        [Description("scp don matteo damage on spawn")]
        public float scpDMdamage { get; set; } = 40;

        [Description("Probability to die and drop an high tier iteam")]
        public int coarseItemDrop { get; set; } = 25;

        [Description("Every time someone duplicate chance to die increments by this number")]
        public int chanceToDieIncrementer { get; set; } = 5;

        [Description("Probability to teleport a SCP player into the 914")]
        public int veryFinechanceToTPaSCP { get; set; } = 10;

        [Description("minimun players to become SCP Gianfranco ")]
        public int veryFineMinumPlayerToSCP { get; set; } = 3;

        [Description("Probability to die on very fine")]
        public int veryFineChanceToDie { get; set; } = 30;

        
    }
}
