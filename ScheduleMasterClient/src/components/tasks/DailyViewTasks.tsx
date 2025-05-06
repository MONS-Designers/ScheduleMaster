import React from "react";
import { ITaskDTO } from "../../types/ITaskDTO";
import { InputText } from "primereact/inputtext";
import { Calendar } from "primereact/calendar";
import { Checkbox } from "primereact/checkbox";

interface Props {
  tasks: ITaskDTO[];
  onUpdate: (task: ITaskDTO) => void;
}

const DailyViewTasks: React.FC<Props> = ({ tasks, onUpdate }) => {
  const today = new Date().toISOString().slice(0, 10);

  const todayTasks = tasks.filter(task => task.startDate?.slice(0, 10) === today);

  const handleChange = (id: number, field: keyof ITaskDTO, value: any) => {
    const updated = todayTasks.find(t => t.id === id);
    if (updated) {
      onUpdate({ ...updated, [field]: value });
    }
  };

  return (
    <div className="flex flex-col gap-3">
      {todayTasks.map(task => (
        <div key={task.id} className="p-3 border-1 border-round shadow-1">
          <InputText
            value={task.title}
            onChange={e => handleChange(task.id, "title", e.target.value)}
            className="w-full mb-2"
          />
          <Calendar
            value={task.startDate ? new Date(task.startDate) : undefined}
            onChange={e => handleChange(task.id, "startDate", e.value?.toISOString())}
            showTime
            className="mb-2"
          />
          <Checkbox
            inputId={`complete-${task.id}`}
            checked={task.isComplete || false}
            onChange={e => handleChange(task.id, "isComplete", e.checked)}
          />
          <label htmlFor={`complete-${task.id}`}>Complete</label>
        </div>
      ))}
    </div>
  );
};

export default DailyViewTasks;
