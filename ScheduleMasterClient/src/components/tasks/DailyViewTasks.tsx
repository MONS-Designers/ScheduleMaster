import React from "react";
import { ITaskDTO } from "../../types/ITaskDTO";

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
    <div>Daily View Coming Soon</div>
  );
};

export default DailyViewTasks;
