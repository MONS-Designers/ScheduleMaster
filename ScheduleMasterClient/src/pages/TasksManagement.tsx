import React, { useState } from "react";
import { ITaskDTO } from "../types/ITaskDTO";
import DailyViewTasks from "../components/tasks/DailyViewTasks";
import { Button } from "primereact/button";
import ListViewTasks from "../components/tasks/ListViewTasks";
import WeeklyViewTasks from "../components/tasks/WeeklyViewTasks";

type ViewMode = "daily" | "weekly" | "list";

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
        isComplete: false,
        description: "Initial task",
        noteContent: '1',
        title: "Review Code",
        isActive: true,
    },
];

const TasksManagement = (/*{ tasks, onUpdate }*/) => {
    const [tasks, onUpdate] = useState(initialTasks);
    const [view, setView] = useState<ViewMode>("daily");

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
            <div className="flex gap-2 m-4">
                <Button icon="pi pi-calendar" text raised rounded aria-label="Daily" onClick={() => setView("daily")} tooltip="Daily View" />
                <Button icon="pi pi-calendar-times" text raised rounded aria-label="Weekly" onClick={() => setView("weekly")} tooltip="Weekly View" />
                <Button icon="pi pi-list" text raised rounded aria-label="List" onClick={() => setView("list")} tooltip="List View" />
            </div>

            {view === "daily" && <DailyViewTasks tasks={tasks} onUpdate={() => { }} />}
            {view === "weekly" && <WeeklyViewTasks tasks={tasks} onUpdate={() => { }} />}
            {view === "list" && <ListViewTasks tasks={tasks} onUpdate={() => { }} />}
        </div>
    );
};

export default TasksManagement;
