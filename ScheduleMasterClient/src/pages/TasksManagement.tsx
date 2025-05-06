import React, { useState } from "react";
import { ITaskDTO } from "../types/ITaskDTO";
import DailyViewTasks from "../components/tasks/DailyViewTasks";
import { Button } from "primereact/button";
import ListViewTasks from "../components/tasks/ListViewTasks";
import WeeklyViewTasks from "../components/tasks/WeeklyViewTasks";
import { SelectButton } from "primereact/selectbutton";

type ViewMode = "daily" | "weekly" | "list";
const ViewModeOptions = [
    { icon: 'pi pi-list', value: 'list' },
    { icon: 'pi pi-calendar-times', value: 'daily' },
    { icon: 'pi pi-calendar', value: 'weekly' }
];
// interface Props {
//   tasks: ITaskDTO[];
//   onUpdate: (updatedTask: ITaskDTO) => void;
// }

const initialTasks: ITaskDTO[] = [
    {
        id: 1,
        priorityId: 2,
        startDate: "2025-05-06T10:00",
        endDate: "2025-05-06T11:00",
        isComplete: true,
        description: "Initial task",
        noteContent: 'this is the note',
        title: "Review Code",
        isActive: true,
    },
    {
        id: 2,
        priorityId: 1,
        startDate: "2025-05-06T10:00",
        endDate: "2025-05-06T11:00",
        isComplete: false,
        description: "Initial task",
        noteContent: 'this is the note',
        title: "Review Code",
        isActive: true,
    },
    {
        id: 3,
        priorityId: 3,
        startDate: "2025-05-06T10:00",
        endDate: "2025-05-06T11:00",
        isComplete: false,
        description: "Initial task",
        noteContent: 'this is the note',
        title: "Review Code",
        isActive: true,
    },
];

const TasksManagement = (/*{ tasks, onUpdate }*/) => {
    const [tasks, onUpdate] = useState(initialTasks);
    const [view, setView] = useState<ViewMode>('list');

    const viewModeTemplate = (option: { icon: string | undefined; }) => {
        return <i className={option.icon}></i>;
    }

    const handleFieldChange = (id: number, field: keyof ITaskDTO, value: any) => {
        const updated = tasks.map(task =>
            task.id === id ? { ...task, [field]: value } : task
        );
        // const updatedTask = updated.find(t => t.id === id)!;
        // onUpdate(updatedTask);
    };

    return (
        <div className="p-4">
            <h1 className='gradient-text'>Tasks</h1>
            <SelectButton value={view} onChange={(e) => setView(e.value)} itemTemplate={viewModeTemplate} optionLabel="value" options={ViewModeOptions} />

            {tasks && tasks.length > 0 && <div>
                {view === "daily" && <DailyViewTasks tasks={tasks} onUpdate={() => { }} />}
                {view === "weekly" && <WeeklyViewTasks tasks={tasks} onUpdate={() => { }} />}
                {view === "list" && <ListViewTasks tasks={tasks} onUpdate={() => { }} />}
            </div>}
        </div>
    );
};

export default TasksManagement;
