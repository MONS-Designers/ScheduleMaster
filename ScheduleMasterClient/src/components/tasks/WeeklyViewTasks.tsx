import React from "react";
import { ITaskDTO } from "../../types/ITaskDTO";

interface Props {
  tasks: ITaskDTO[];
  onUpdate: (task: ITaskDTO) => void;
}

const WeeklyViewTasks: React.FC<Props> = (/*{ tasks, onUpdate }*/) => {
  // You can group by date.getDay() here and render accordingly
  return <div>Weekly View Coming Soon</div>;
};

export default WeeklyViewTasks;
