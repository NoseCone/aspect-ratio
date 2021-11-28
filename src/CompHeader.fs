module CompHeader

open Fable.Core
open Sutil
open Sutil.DOM
open Sutil.Attr
open Thoth.Json
open Thoth.Fetch

open Types

let compHeader (comp: Comp) (nominals: Nominals) = Html.div [
        class' "container"
        Html.div [
            class' "tile is-ancestor"
            Attr.style "flexWrap: wrap"
            Html.div [
                class' "tile"
                Html.div [
                    class' "tile is-parent"
                    Html.div [
                        class' "tile is-child box"
                        Html.p [
                            class' "title is-3"
                            text comp.compName
                        ]
                        Html.p [
                            class' "title is-5"
                            text comp.compSlug
                        ]
                        Html.div [
                            class' "example"
                            Html.div [
                                class' "field is-grouped is-grouped-multiline"
                                Html.div [
                                    class' "control"
                                    Html.div [
                                        class' "tags has-addons"
                                        Html.span [
                                            class' "tag"
                                            text "UTC offset"
                                        ]
                                        Html.span [
                                            class' "tag is-warning"
                                            text (string comp.utcOffset.timeZoneMinutes)
                                        ]
                                    ]
                                ]
                                Html.div [
                                    class' "control"
                                    Html.div [
                                        class' "tags has-addons"
                                        Html.span [
                                            class' "tag"
                                            text "minimum distance"
                                        ]
                                        Html.span [
                                            class' "tag is-black"
                                            text nominals.free
                                        ]
                                    ]
                                ]
                                Html.div [
                                    class' "control"
                                    Html.div [
                                        class' "tags has-addons"
                                        Html.span [
                                            class' "tag"
                                            text "nominal distance"
                                        ]
                                        Html.span [
                                            class' "tag is-info"
                                            text nominals.distance
                                        ]
                                    ]
                                ]
                                Html.div [
                                    class' "control"
                                    Html.div [
                                        class' "tags has-addons"
                                        Html.span [
                                            class' "tag"
                                            text "nominal time"
                                        ]
                                        Html.span [
                                            class' "tag is-success"
                                            text nominals.time
                                        ]
                                    ]
                                ]
                                Html.div [
                                    class' "control"
                                    Html.div [
                                        class' "tags has-addons"
                                        Html.span [
                                            class' "tag"
                                            text "nominal goal"
                                        ]
                                        Html.span [
                                            class' "tag is-primary"
                                            text (string nominals.goal)
                                        ]
                                    ]
                                ]
                                Html.div [
                                    class' "control"
                                    Html.div [
                                        class' "tags has-addons"
                                        Html.span [
                                            class' "tag"
                                            text "score-back time"
                                        ]
                                        Html.span [
                                            class' "tag is-danger"
                                            text (Option.defaultValue "" <| Option.map string comp.scoreBack)
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]