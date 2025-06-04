// ScheduleManagement.tsx
import React, { useEffect, useState } from "react";
import FullCalendar, { EventClickArg, EventContentArg } from "@fullcalendar/react";
import timeGridPlugin from "@fullcalendar/timegrid";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin from "@fullcalendar/interaction";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Calendar } from "primereact/calendar";
import { Dropdown } from "primereact/dropdown";
import { format } from "date-fns";
import { HDate } from "@hebcal/core";

interface Lesson {
    id: string;
    title: string;
    date: Date;
    startTime: string;
    endTime: string;
    placementStatusId: number;
    groupId: number;
}

const placementColors: Record<number, string> = {
    1: "#90ee90",
    2: "#f08080",
    3: "#87ceeb",
};

const ScheduleManagement: React.FC = () => {
    const [lessons, setLessons] = useState<Lesson[]>([]);
    const [selectedLesson, setSelectedLesson] = useState<Lesson | null>(null);
    const [dialogVisible, setDialogVisible] = useState(false);
    const [deleteDialogVisible, setDeleteDialogVisible] = useState(false);
    const [isEdit, setIsEdit] = useState(false);
    const [selectedGroupId, setSelectedGroupId] = useState<number>(1);

    useEffect(() => {
        const stored = localStorage.getItem("lessons");
        if (stored) setLessons(JSON.parse(stored));
    }, []);

    useEffect(() => {
        localStorage.setItem("lessons", JSON.stringify(lessons));
    }, [lessons]);

    const handleDateSelect = (info: any) => {
        const date = info.start;
        setSelectedLesson({
            id: `${Date.now()}-${Math.random()}`,
            title: "",
            date,
            startTime: "08:00",
            endTime: "09:00",
            placementStatusId: 1,
            groupId: selectedGroupId,
        });
        setIsEdit(false);
        setDialogVisible(true);
    };

    const handleLessonClick = (arg: EventClickArg) => {
        const lesson = lessons.find((l) => l.id === arg.event.id);
        if (lesson) {
            setSelectedLesson(lesson);
            setIsEdit(true);
            setDialogVisible(true);
        }
    };

    const saveLesson = () => {
        if (!selectedLesson) return;
        if (isEdit) {
            setLessons((prev) =>
                prev.map((l) => (l.id === selectedLesson.id ? selectedLesson : l))
            );
        } else {
            setLessons((prev) => [...prev, selectedLesson]);
        }
        setDialogVisible(false);
    };

    const deleteLesson = () => {
        if (selectedLesson) {
            setLessons((prev) => prev.filter((l) => l.id !== selectedLesson.id));
        }
        setDeleteDialogVisible(false);
        setDialogVisible(false);
    };

    const getHebrewDate = (date: Date) => {
        try {
            const hd = new HDate(date);
            return hd.renderGematriya();
        } catch {
            return "";
        }
    };

    const eventContent = (arg: EventContentArg) => {
        const lesson = lessons.find((l) => l.id === arg.event.id);
        return (
            <div style={{ padding: "2px" }}>
                <div style={{ fontWeight: 600 }}>{arg.event.title}</div>
                <div style={{ fontSize: "0.75rem" }}>{getHebrewDate(arg.event.start)}</div>
            </div>
        );
    };

    return (
        <div className="p-4">
            <Button
                label="הוסף שיעור"
                icon="pi pi-plus"
                onClick={() => {
                    setSelectedLesson({
                        id: `${Date.now()}-${Math.random()}`,
                        title: "",
                        date: new Date(),
                        startTime: "08:00",
                        endTime: "09:00",
                        placementStatusId: 1,
                        groupId: selectedGroupId,
                    });
                    setIsEdit(false);
                    setDialogVisible(true);
                }}
                text rounded
            />

            <FullCalendar
  plugins={[timeGridPlugin, dayGridPlugin, interactionPlugin]}
  initialView="timeGridWeek"
  headerToolbar={{
    left: "prev,next today",
    center: "title",
    right: "dayGridMonth,timeGridWeek,timeGridDay,yearGrid", // נוסיף yearGrid בהמשך
  }}
  views={{
    yearGrid: {
      type: "dayGridMonth",
      duration: { years: 1 },
      buttonText: "שנה",
    },
  }}
  selectable
  editable
  select={handleDateSelect}
  events={lessons.map((l) => ({
    id: l.id,
    title: l.title,
    start: new Date(`${format(l.date, "yyyy-MM-dd")}T${l.startTime}`),
    end: new Date(`${format(l.date, "yyyy-MM-dd")}T${l.endTime}`),
    backgroundColor: placementColors[l.placementStatusId] || "#ccc",
  }))}
  eventClick={handleLessonClick}
  eventContent={eventContent}
  height="calc(80vh)"
  slotMinTime="07:00:00"
  slotMaxTime="22:00:00"
/>


            <Dialog
                header={isEdit ? "עריכת שיעור" : "הוספת שיעור"}
                visible={dialogVisible}
                onHide={() => setDialogVisible(false)}
            >
                <div className="flex flex-col gap-3">
                    <InputText
                        placeholder="שם שיעור"
                        value={selectedLesson?.title || ""}
                        onChange={(e) =>
                            setSelectedLesson((prev) =>
                                prev ? { ...prev, title: e.target.value } : prev
                            )
                        }
                    />
                    <Calendar
                        value={selectedLesson?.date}
                        onChange={(e) =>
                            setSelectedLesson((prev) =>
                                prev ? { ...prev, date: e.value as Date } : prev
                            )
                        }
                        dateFormat="dd/mm/yy"
                    />
                    <InputText
                        placeholder="שעת התחלה (08:00)"
                        value={selectedLesson?.startTime || ""}
                        onChange={(e) =>
                            setSelectedLesson((prev) =>
                                prev ? { ...prev, startTime: e.target.value } : prev
                            )
                        }
                    />
                    <InputText
                        placeholder="שעת סיום (09:00)"
                        value={selectedLesson?.endTime || ""}
                        onChange={(e) =>
                            setSelectedLesson((prev) =>
                                prev ? { ...prev, endTime: e.target.value } : prev
                            )
                        }
                    />
                    <Dropdown
                        options={[
                            { label: "שיבוץ רגיל", value: 1 },
                            { label: "הושעה", value: 2 },
                            { label: "מוקפא", value: 3 },
                        ]}
                        value={selectedLesson?.placementStatusId}
                        onChange={(e) =>
                            setSelectedLesson((prev) =>
                                prev ? { ...prev, placementStatusId: e.value } : prev
                            )
                        }
                        placeholder="בחר סטטוס"
                    />
                    <div className="flex gap-2 justify-end">
                        {isEdit && (
                            <Button
                                label="מחיקה"
                                icon="pi pi-trash"
                                className="p-button-danger"
                                onClick={() => setDeleteDialogVisible(true)}
                                text rounded
                            />
                        )}
                        <Button
                            label={isEdit ? "שמור שינויים" : "הוסף שיעור"}
                            onClick={saveLesson}
                            text rounded
                        />
                    </div>
                </div>
            </Dialog>

            <Dialog
                header="אישור מחיקה"
                visible={deleteDialogVisible}
                onHide={() => setDeleteDialogVisible(false)}
                footer={
                    <div className="flex justify-end gap-2">
                        <Button label="ביטול" onClick={() => setDeleteDialogVisible(false)} text rounded />
                        <Button label="מחק" className="p-button-danger" onClick={deleteLesson} text rounded />
                    </div>
                }
            >
                האם את בטוחה שברצונך למחוק את השיעור?
            </Dialog>
        </div>
    );
};

export default ScheduleManagement;
