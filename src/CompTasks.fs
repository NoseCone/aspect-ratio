module CompTasks

open Sutil
open Sutil.DOM
open Sutil.Attr

let taskRow (task: {|taskName: string; tps: string; distance: string; stopped: bool; cancelled: bool|}) = Html.tr [
        Html.td "1"
        Html.td [
            class' "td-task-name"
            text task.taskName
        ]
        Html.td [
            class' "td-task-tps"
            text task.tps
        ]
        Html.td [
            class' "td-task-dist"
            text task.distance
        ]
        Html.td [
            class' "td-task-stopped"
            text (if task.stopped then "STOPPED" else "")
        ]
        Html.td [
            class' "td-task-cancelled"
            text (if task.cancelled then "CANCELLED" else "")
        ]
    ]

let tasksTable (tasks: {|taskName: string; tps: string; distance: string; stopped: bool; cancelled: bool|} list)= Html.table [
        class' "table is-striped"
        Html.thead [
            Html.tr [
                Html.th "#"
                Html.th [
                    class' "th-task-name"
                    text "Name"
                ]
                Html.th [
                    class' "th-task-tps"
                    text "Turnpoints"
                ]
                Html.th [
                    class' "th-task-dist"
                    text "Distance"
                ]
                Html.th [
                    class' "th-task-stopped"
                    text "Stopped"
                ]
                Html.th [
                    class' "th-task-cancelled"
                    text "Cancelled"
                ]
            ]
        ]
        Html.tbody (List.map taskRow tasks)
    ]