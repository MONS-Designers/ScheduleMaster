import React from "react";
import { ITaskDTO } from "../../types/ITaskDTO";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { InputText } from "primereact/inputtext";
import { Calendar } from "primereact/calendar";
import { Checkbox } from "primereact/checkbox";

interface Props {
  tasks: ITaskDTO[];
  onUpdate: (task: ITaskDTO) => void;
}

const ListViewTasks: React.FC<Props> = ({ tasks, onUpdate }) => {
  const onCellEdit = (task: ITaskDTO, field: keyof ITaskDTO, value: any) => {
    onUpdate({ ...task, [field]: value });
  };

  return (
    <DataTable value={tasks} editMode="cell">
      <Column
        field="title"
        header="Title"
        editor={options => (
          <InputText
            value={options.rowData.title}
            onChange={e => onCellEdit(options.rowData, "title", e.target.value)}
          />
        )}
      />
      <Column
        field="startDate"
        header="Start"
        body={row => new Date(row.startDate).toLocaleString()}
        editor={options => (
          <Calendar
            // value={row.startDate ? new Date(row.startDate) : undefined}
            onChange={e => onCellEdit(options.rowData, "startDate", e.value?.toISOString())}
            showTime
          />
        )}
      />
      <Column
        field="isComplete"
        header="Complete"
        body={row => (row.isComplete ? "Yes" : "No")}
        editor={options => (
          <Checkbox
            checked={options.rowData.isComplete}
            onChange={e => onCellEdit(options.rowData, "isComplete", e.checked)}
          />
        )}
      />
    </DataTable>
  );
};

export default ListViewTasks;
