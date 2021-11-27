module Comps

open Sutil
open Sutil.DOM
open Sutil.Attr

open Types

let view (page: IStore<Page>, tab: IStore<Tab option>) =
    Html.div [
        Attr.id "content"
        class' "content"
        Html.div [
            class' "tile is-ancestor"
            Html.div [
                class' "tile is-parent" 
                Html.article [
                    class' "tile is-child notification is-light"
                    Html.p [
                        class' "title"
                        text "Aspect Ratio"
                    ]
                    Html.p [
                        class' "subtitle"
                        text "Comps scored with "
                        Html.a [
                            Attr.href "https://flaretiming.com"
                            text "Flare Timing"
                        ]
                        text " and presented with "
                        Html.a [
                            Attr.href "https://sutil.dev/"
                            text "Sutil"
                        ]
                    ]
                ]
            ]
        ]
        Html.p [
            text "Want "
            Html.a [
                Attr.href "https://flaretiming.com/posts/2018-12-19-add-a-comp.html"
                text "your comp here"
            ]
            text "?"
        ]
        Html.div [
            class' "tile is-ancestor"
            Html.div [
                class' "tile is-vertical is-5"
                Html.div [
                    class' "tile"
                    Html.div [
                        class' "tile is-parent is-vertical"
                        Html.div [
                            class' "tile is-child box"
                            Html.h3 [
                                text "Paragliding"
                            ]
                            Html.p [
                                Html.ul [
                                    Html.li [
                                        text "Italian Open "
                                        Html.a [
                                            Attr.href "#/comp-prefix/2020-italy-open"
                                            text "2020"
                                        ]
                                    ]
                                    Html.li [
                                        text "Dalmatian "
                                        Html.a [
                                            Attr.href "#/comp-prefix/2019-dalmatian"
                                            text "2019"
                                        ]
                                        text " "
                                        Html.a [
                                            Attr.href "#/comp-prefix/2018-dalmatian"
                                            text "2018"
                                        ]
                                    ]
                                    Html.ul [
                                        Html.p [
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        Html.div [
                            class' "tile is-child box"
                            Html.h3 [
                                text "Comp Archetypes"
                            ]
                            Html.p [
                                Html.ul [
                                    Html.li [
                                        Html.a [
                                            Attr.href "#/comp-prefix/1976-never-land"
                                            text "1976 Never Land"
                                        ]
                                    ]
                                    Html.li [
                                        Html.a [
                                            Attr.href "#/comp-prefix/1989-lift-lines"
                                            text "1989 Lift Lines"
                                        ]
                                    ]
                                    Html.ul [
                                        Html.p [
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                class' "tile is-vertical is-7"
                Html.div [
                    class' "tile"
                    Html.div [
                        class' "tile is-parent is-vertical"
                        Html.div [
                            class' "tile is-child box"
                            Html.h3 [
                                text "Hang Gliding"
                            ]
                            Html.h5 [
                                text "Oceania"
                            ]
                            Html.ul [
                                Html.li [
                                    text "Forbes Flatlands "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2018-forbes"
                                        text "2018"
                                    ]
                                    text " "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2017-forbes"
                                        text "2017"
                                    ]
                                    text " "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2016-forbes"
                                        text "2016"
                                    ]
                                    text " "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2015-forbes"
                                        text "2015"
                                    ]
                                    text " "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2014-forbes"
                                        text "2014"
                                    ]
                                    text " "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2012-forbes"
                                        text "2012"
                                    ]
                                ]
                                Html.li [
                                    text "Dalby Big Air "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2017-dalby"
                                        text "2017"
                                    ]
                                ]
                            ]
                            Html.h5 [
                                text "Europe"
                            ]
                            Html.ul [
                                Html.li [
                                    text "Meduno "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2020-meduno"
                                        text "2020"
                                    ]
                                ]
                                Html.li [
                                    text "Tolmezzo "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2019-italy"
                                        text "2019"
                                    ]
                                ]
                            ]
                            Html.h5 [
                                text "Americas"
                            ]
                            Html.ul [
                                Html.li [
                                    text "Green Swamp Klassic 2016 "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2016-greenswamp"
                                        text "Topless"
                                    ]
                                    text " "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2016-greenswamp-sport"
                                        text "Kingposted"
                                    ]
                                ]
                                Html.li [
                                    text "Big Spring "
                                    Html.a [
                                        Attr.href "2016-big-spring"
                                        text "2016"
                                    ]
                                ]
                                Html.li [
                                    text "QuestAir Open "
                                    Html.a [
                                        Attr.href "#/comp-prefix/2016-quest"
                                        text "2016"
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]