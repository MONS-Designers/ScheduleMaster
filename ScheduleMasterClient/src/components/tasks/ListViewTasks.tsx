import React from "react";
import { ITaskDTO } from "../../types/ITaskDTO";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { InputText } from "primereact/inputtext";
import { Calendar } from "primereact/calendar";
import { Checkbox } from "primereact/checkbox";
import { priorityMap } from "../../utils/priorityMap";
import { Chip } from "primereact/chip";
import './TasksView.css';
import { Button } from "primereact/button";

interface Props {
  tasks: ITaskDTO[];
  onUpdate: (task: ITaskDTO) => void;
}

const ListViewTasks: React.FC<Props> = ({ tasks, onUpdate }) => {
  const onCellEdit = (task: ITaskDTO, field: keyof ITaskDTO, value: any) => {
    onUpdate({ ...task, [field]: value });
  };

  const onRowEditComplete = (e: any) => {
    // let _teachers = [...data];
    // let { newData, index } = e;

    // _teachers[index] = newData;

    // setData(_teachers);
    // Simulate saving to the server
  };


  const handleDelete = (teacherId: number): void => {
    // Open a dialog with a question
  };

  const handleEdit = (id: number): void => {

  };

  return (
    <>
      <DataTable value={tasks} dataKey='id' sortMode="multiple" paginator rows={25} editMode="row" onRowEditComplete={onRowEditComplete} emptyMessage="Hoora! You have no tasks here!">
        <Column header="#" body={(_, options) => options.rowIndex + 1} />
        <Column className="priority" field="priorityId" sortable header="Priority" body={row => {
          const priority = priorityMap[row.priorityId as keyof typeof priorityMap] || { label: "Unknown", color: "var(--gray-300)" };
          return (
            <Chip label={priority.label} style={{ backgroundColor: priority.color }} />
          );
        }}
        />
        <Column field="isComplete" sortable header="Complete" body={row => (
          <i
            className={`pi ${row.isComplete ? "pi-check-circle Completed" : "pi-times-circle Incomplete"}`}
            aria-label={row.isComplete ? "Completed" : "Incomplete"}
          />
        )}
          editor={options => (
            <Checkbox
              checked={options.rowData.isComplete}
              onChange={e => onCellEdit(options.rowData, "isComplete", e.checked)}
            />
          )}
        />
        <Column className="bold-title" field="title" sortable header="Title" editor={options => (
          <InputText value={options.rowData.title} onChange={e => onCellEdit(options.rowData, "title", e.target.value)} />
        )}
        />
        <Column field="startDate" sortable header="Start" body={row => new Date(row.startDate).toLocaleString()} editor={options => (
          <Calendar showTime
            value={options.rowData.startDate ? new Date(options.rowData.startDate) : undefined}
            onChange={e => onCellEdit(options.rowData, "startDate", e.value?.toISOString())}
          />
        )}
        />
        <Column field="endDate" sortable header="End" body={row => new Date(row.endDate).toLocaleString()} editor={options => (
          <Calendar showTime
            value={options.rowData.endDate ? new Date(options.rowData.endDate) : undefined}
            onChange={e => onCellEdit(options.rowData, "endDate", e.value?.toISOString())}
          />
        )}
        />
        <Column field="description" sortable header="Description" body={row => row.description || "-"}
          editor={options => (
            <textarea rows={2} className="p-inputtext p-component w-full" value={options.rowData.description || ""} onChange={e => onCellEdit(options.rowData, "description", e.target.value)} />
          )}
        />
        <Column field="noteContent" sortable header="Note" body={row => row.noteContent || "-"}
          editor={options => (
            <InputText
              value={options.rowData.noteContent || ""}
              onChange={e => onCellEdit(options.rowData, "noteContent", e.target.value)}
              className="w-full"
            />
          )}
        />
        <Column header='Edit' rowEditor={true} />
        <Column header='Delete' body={(rowData) => (
          <Button icon="pi pi-trash" onClick={() => handleDelete(rowData.teacherId)} rounded text severity="danger" />
        )} />
      </DataTable>
    </>
  );
};

export default ListViewTasks;
