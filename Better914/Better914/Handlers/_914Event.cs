using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events;
using Scp914;
using Exiled.API;
using UnityEngine;
using System;
using CustomPlayerEffects;
using System.Collections.Generic;

namespace Better914.Handlers
{
    class _914Event
    {

        private Config config = Better914.pluginInstance.Config;
        public _914Event()
        {
            
        }

        public void OnPlayerDead(DiedEventArgs ev)
        {
            if (ev.Target.Scale != new Vector3(1, 1f, 1))
            {
                ev.Target.Scale = new Vector3(1, 1f, 1);
            }
        }

        private int chanceToDie = 0;
        public void OnUpgrading(UpgradingItemsEventArgs ev)
        {

            if (ev.KnobSetting == Scp914Knob.Rough)
            {
                ev.Players.ForEach((player) => {

                    int prob = new System.Random().Next(0, 101);
                    if (prob < config.roughConversionProbabilityTo492)
                    {
                        player.SetRole(RoleType.Scp0492, true, false);
                        player.Health = 90f;
                    }
                    else player.Hurt(config.roughDamage);

                });
                //Creare oggetti con un minimo di persone
                if (ev.Players.Count > config.roughMinimunPlayers)
                {

                    int num = new System.Random().Next(0, 4);
                    switch (num)
                    {
                        case 0:
                            Exiled.API.Extensions.Item.Spawn(ItemType.GunUSP, 10f, ev.Scp914.output.position);
                            break;
                        case 1:
                            Exiled.API.Extensions.Item.Spawn(ItemType.KeycardJanitor, 100f, ev.Scp914.output.position);
                            break;
                        case 2:
                            Exiled.API.Extensions.Item.Spawn(ItemType.Flashlight, 100f, ev.Scp914.output.position);
                            break;
                        case 3:
                            Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);
                            Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);

                            break;

                        default:
                            break;
                    }
                }

            }
            if (ev.KnobSetting == Scp914Knob.Coarse)

            {
                ev.Players.ForEach((player) => {
                    int prob = new System.Random().Next(0, 101);
                    if (prob < config.coarseScpDMProbability)
                    {
                        player.Scale = new Vector3(1, 0.2f, 1);
                        player.MaxEnergy = player.MaxEnergy * 1.5f;
                        //Aggiungere velocità
                        player.ReferenceHub.playerEffectsController.EnableEffect<Scp207>();
                        player.Broadcast(6, "Sei diventato <color=red>SCP DON MATTEO</color>");
                        player.Hurt(config.scpDMdamage);
                        player.IsFriendlyFireEnabled = true;
                    }
                    if (prob > config.coarseScpDMProbability && prob > config.coarseScpDMProbability + config.coarseItemDrop)
                    {
                        player.Hurt(player.Health);
                        int num = new System.Random().Next(0, 4);
                        switch (num)
                        {
                            case 0:
                                Exiled.API.Extensions.Item.Spawn(ItemType.GunE11SR, 30f, ev.Scp914.output.position);
                                break;
                            case 1:
                                Exiled.API.Extensions.Item.Spawn(ItemType.KeycardFacilityManager, 100f, ev.Scp914.output.position);
                                break;
                            case 2:
                                Exiled.API.Extensions.Item.Spawn(ItemType.SCP268, 100f, ev.Scp914.output.position);
                                break;
                            case 3:
                                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);
                                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);
                                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);
                                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);
                                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);
                                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 100f, ev.Scp914.output.position);

                                break;

                            default:
                                break;
                        }

                    }
                    if(prob > config.coarseScpDMProbability + config.coarseItemDrop && prob < config.coarseScpDMProbability + config.coarseItemDrop + config.coarseHealthReductionProbability)
                    {
                        player.Hurt(70);
                        player.MaxHealth = 30;
                    }
                    


                });
               


            }
            if (ev.KnobSetting == Scp914Knob.OneToOne)
            {

                Player player1 = ev.Players[0];
                Player player2 = ev.Players[1];
                if (player1.Role != player2.Role)
                {



                    var buffer = player1.Role;
                    player1.SetRole(player2.Role, true);
                    player2.SetRole(buffer, true);
                    int prob = new System.Random().Next(0, 101);

                    if (prob < chanceToDie)
                    {
                        player1.Hurt(player1.Health);

                    }
                    else
                    {
                        ev.Items.ForEach((item) => { Exiled.API.Extensions.Item.Spawn(item.ItemId, item.durability, ev.Scp914.output.position); });
                        chanceToDie += config.chanceToDieIncrementer;
                    }
                    player1.Broadcast(4, chanceToDie.ToString());
                    player2.Broadcast(4, chanceToDie.ToString());

                }


                //Swap
                //Duplicare
            }
            if (ev.KnobSetting == Scp914Knob.Fine)
            {
                //Diventare scienziato
                //Ricette
            }
            if (ev.KnobSetting == Scp914Knob.VeryFine)
            {
                
               if (ev.Players.Count > 0)
                {
                    int prob = new System.Random().Next(0, 101);
                    if (prob < config.veryFinechanceToTPaSCP)//Teletrasportare un scp 
                    {
                        var players = Player.List;
                        foreach (var tmp in players)
                        {
                            if (tmp.Side == Exiled.API.Enums.Side.Scp)
                            {
                                tmp.Position = ev.Scp914.output.position;
                                break;
                            }
                        }
                    }
                }

               

               if(ev.Players.Count == 1 && containsItem(ev.Items,ItemType.MicroHID) && containsItem(ev.Items,ItemType.KeycardO5))
               {
                    ev.Players[0].Broadcast(5, "Hai contenuto l'scp 096 con successo");
                    ev.Items.Clear();
                    ev.Players[0].Hurt(ev.Players[0].MaxHealth);
                    var players = Player.List;
                    foreach(var player in players)
                    {
                        if(player.Role == RoleType.Scp096)
                        {
                            player.Hurt(player.MaxHealth);
                        }
                    }
                }

               if (ev.Players.Count>=config.veryFineMinumPlayerToSCP)
                    {
                        int prob = new System.Random().Next(0, ev.Players.Count);
                        var player = ev.Players[prob];
                        
                        player.MaxHealth = 200;
                        player.Health = 200;
                        player.MaxEnergy = 200;
                        player.Broadcast(5,"Sei diventato <color=red> SCP GIAN FRANCO </color>");
                    }
               ev.Players.ForEach((player) => {
                    int prob = new System.Random().Next(0, 101);
                    //Potenziarsi piu stamina piu vita
                    
                    if (prob < config.veryFineChanceToDie)
                    {
                        player.Hurt(99);
                    }


               });
                
                //Morire 
                //Ricette
                
            }

            

        }
        private bool containsItem(List<Pickup> items,ItemType item)
        {
            foreach(var i in items)
            {
                if(i.ItemId == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
