﻿/***************************************************************\
* File Name : UpcomingEventsGump.cs                             *
* Developer : Taryen(Mark S.)                                   *
* Orig. Date: 02/17/2013                                        *
* Desc.     : A gump that lists the upcoming events that are    *
*               scheduled. Allows the viewing of event details  *
*               and registering for the event.                  *
\***************************************************************/

/************************  Changelog  ***************************\
|    Date    |                    Changes                        |
------------------------------------------------------------------
|  02/17/13  | Initial File                                      |
\****************************************************************/

using System;

using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

using Tournaments.Items;

namespace Tournaments.Gumps
{
    public class ArenaTypeGump : Gump
    {
        Mobile caller;
        ArenaControl a;

        public ArenaTypeGump(Mobile from, ArenaControl arena)
            : this()
        {
            caller = from;
            a = arena;
            TypeInfo();
        }

        public ArenaTypeGump()
            : base(200, 200)
        {
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
        }

        public void TypeInfo()
        {
            AddPage(0);
            AddBackground(0, 44, 260, 180, 9250);
            AddBackground(0, 0, 260, 47, 9250);
            AddLabel(100, 14, 0, @"Arena Type");

            AddLabel(60, 60, 0, @"One vs. One");
            AddRadio(25, 60, 208, 209, a.Type == ArenaType.OneVsOne ? true : false, 0);

            AddLabel(60, 90, 0, @"Two vs. Two");
            AddRadio(25, 90, 208, 209, a.Type == ArenaType.TwoVsTwo ? true : false, 1);

            AddLabel(60, 120, 0, @"Three vs. Three");
            AddRadio(25, 120, 208, 209, a.Type == ArenaType.ThreeVsThree ? true : false, 2);

            AddLabel(60, 150, 0, @"Four vs. Four");
            AddRadio(25, 150, 208, 209, a.Type == ArenaType.FourVsFour ? true : false, 3);

            AddLabel(60, 180, 0, @"Five vs. Five");
            AddRadio(25, 180, 208, 209, a.Type == ArenaType.FiveVsFive ? true : false, 4);

            AddButton(218, 188, 4005, 4007, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                {
                    break;
                }
                case 1:
                {
                    switch (info.Switches[0])
                    {
                        case 1:
                        {
                            a.Type = ArenaType.TwoVsTwo;
                            break;
                        }
                        case 2:
                        {
                            a.Type = ArenaType.ThreeVsThree;
                            break;
                        }
                        case 3:
                        {
                            a.Type = ArenaType.FourVsFour;
                            break;
                        }
                        case 4:
                        {
                            a.Type = ArenaType.FiveVsFive;
                            break;
                        }
                        default:
                        {
                            a.Type = ArenaType.OneVsOne;
                            break;
                        }
                    }

                    from.SendGump(new ArenaInfoGump(from, a));
                    break;
                }
            }
        }
    }
}