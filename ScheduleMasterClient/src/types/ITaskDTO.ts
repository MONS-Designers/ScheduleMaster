export interface ITaskDTO {
  id: number;
  priorityId: number;
  startDate?: string;
  endDate?: string;
  isComplete?: boolean;
  description?: string;
  noteContent: string;
  title: string;
  isActive: boolean;
};
