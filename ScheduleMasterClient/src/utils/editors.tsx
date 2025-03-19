import { ColumnEditorOptions } from 'primereact/column';
import { InputMask } from 'primereact/inputmask';
import { InputText } from 'primereact/inputtext';
import { MultiSelect } from 'primereact/multiselect';

export const emailEditor = (options: ColumnEditorOptions) => <InputText type='email' value={options.value} onChange={(e) => options.editorCallback?.(e.target.value)} placeholder='example@example.com' required className='w-full' />;

export const firstNameEditor = (options: ColumnEditorOptions) => <InputText value={options.value} onChange={(e) => options.editorCallback?.(e.target.value)} placeholder='Israel' className='w-full' />

export const lastNameEditor = (options: ColumnEditorOptions) => <InputText value={options.value} onChange={(e) => options.editorCallback?.(e.target.value)} placeholder='Israeli' className='w-full' />;

export const telephoneEditor = (options: ColumnEditorOptions) => <InputMask mask='(99) 9999-999' value={options.value || ''} onChange={(e) => options.editorCallback?.(e.target.value)} placeholder='Telephone' className='w-full' />

export const cellPhoneEditor = (options: ColumnEditorOptions) => <InputMask mask='(999) 9999-999' value={options.value || ''} onChange={(e) => options.editorCallback?.(e.target.value)} placeholder='Cell Phone' className='w-full' />

export const listEditor = (options: ColumnEditorOptions, optionList: object[]) => <MultiSelect value={options.value} options={optionList} onChange={(e) => options.editorCallback?.(e.value)} placeholder='Select Subjects' className='w-full' display='chip' />