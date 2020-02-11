import React, { Component } from 'react';
import { Link } from 'office-ui-fabric-react/lib/Link';
import {
    DetailsList,
    Selection,
    IColumn,
    buildColumns,
    IColumnReorderOptions,
    IDragDropEvents,
    IDragDropContext,
    DetailsRow,
    IDetailsRowStyles,
    IDetailsListProps,
} from 'office-ui-fabric-react/lib/DetailsList';
import { MarqueeSelection } from 'office-ui-fabric-react/lib/MarqueeSelection';
import { TextField, ITextFieldStyles } from 'office-ui-fabric-react/lib/TextField';
import { Toggle } from 'office-ui-fabric-react/lib/Toggle';
import { ITableItem } from './contracts/ITableItem';
import { ITableColumns } from './contracts/ITableColumns';
import { TableItem } from './components/table-item.component';
import { getTheme, mergeStyles } from 'office-ui-fabric-react/lib/Styling';
import styles from './table.scss';
import { Image, ImageFit } from 'office-ui-fabric-react';

interface Props {
    title: string;
    items: ITableItem[];
}
interface State {
    items: ITableItem[];
    columns: IColumn[];
    isColumnReorderEnabled: boolean;
    frozenColumnCountFromStart: string;
    frozenColumnCountFromEnd: string;
}

export default class TableComponent extends Component<Props, State> {
    private _selection: Selection;
    private _dragDropEvents: IDragDropEvents;
    private _draggedItem: ITableItem | undefined;
    private _draggedIndex: number;

    state: State = {
        items: [] as any,
        columns: [] as any,
        isColumnReorderEnabled: true,
        frozenColumnCountFromStart: '',
        frozenColumnCountFromEnd: '',
    };

    constructor(props: Props) {
        super(props);

        this._selection = new Selection();
        this._dragDropEvents = this._getDragDropEvents();
        this._draggedIndex = -1;
        const items = this.createListItems(10, 'hello');

        this.state = {
            items: items,
            columns: this._buildColumns(items),
            isColumnReorderEnabled: true,
            frozenColumnCountFromStart: '1',
            frozenColumnCountFromEnd: '0',
        };
    }

    createListItems(count: number, title: string): ITableItem[] {
        return Array.from(new Array(count), (val, index) => ({
            itemId: 'dskjvnmlsdvm',
            dueDate: new Date(),
            priority: 0,
            id: index.toString(),
        }));
    }

    theme = getTheme();
    margin = '0 30px 20px 0';
    dragEnterClass = mergeStyles({
        backgroundColor: this.theme.palette.neutralLight,
    });
    controlWrapperClass = mergeStyles({
        display: 'flex',
        flexWrap: 'wrap',
    });
    textFieldStyles: Partial<ITextFieldStyles> = {
        root: { margin: this.margin },
        fieldGroup: { maxWidth: '100px' },
    };

    private _onRenderRow: IDetailsListProps['onRenderRow'] = props => {
        const customStyles: Partial<IDetailsRowStyles> = {};
        if (props) {
            // if (props.itemIndex % 2 === 0) {
            //     // Every other row renders with a different background color
            //     customStyles.root = { backgroundColor: this.theme.palette.themeLighterAlt };
            // }

            return <DetailsRow {...props} styles={customStyles} />;
        }
        return null;
    };

    render() {
        const {
            items,
            columns,
            isColumnReorderEnabled,
            frozenColumnCountFromStart,
            frozenColumnCountFromEnd,
        } = this.state;

        const { title } = this.props;

        return (
            <div id={styles.container}>
                <div id={styles.tableTitle}>
                    <p>{title}</p>
                </div>
                {/* <div className={this.controlWrapperClass}>
                    <Toggle
                        label="Enable column reorder"
                        checked={isColumnReorderEnabled}
                        onChange={this._onChangeColumnReorderEnabled}
                        onText="Enabled"
                        offText="Disabled"
                        styles={{ root: { margin: this.margin } }}
                    />
                    <TextField
                        label="Number of left frozen columns"
                        onGetErrorMessage={this._validateNumber}
                        value={frozenColumnCountFromStart}
                        onChange={this._onChangeStartCountText}
                        styles={this.textFieldStyles}
                    />
                    <TextField
                        label="Number of right frozen columns"
                        onGetErrorMessage={this._validateNumber}
                        value={frozenColumnCountFromEnd}
                        onChange={this._onChangeEndCountText}
                        styles={this.textFieldStyles}
                    />
                </div> */}
                <MarqueeSelection selection={this._selection}>
                    <DetailsList
                        setKey="items"
                        items={items}
                        // onRenderRow={this._onRenderRow}
                        columns={columns}
                        // selection={this._selection}
                        // selectionPreservedOnEmptyClick={true}
                        // onItemInvoked={this._onItemInvoked}
                        onRenderItemColumn={this._onRenderItemColumn}
                        // dragDropEvents={this._dragDropEvents}
                        // columnReorderOptions={
                        //     this.state.isColumnReorderEnabled ? this._getColumnReorderOptions() : undefined
                        // }
                        ariaLabelForSelectionColumn="Toggle selection"
                        ariaLabelForSelectAllCheckbox="Toggle selection for all items"
                        checkButtonAriaLabel="Row checkbox"
                    />
                </MarqueeSelection>
            </div>
        );
    }

    private _handleColumnReorder = (draggedIndex: number, targetIndex: number) => {
        const draggedItems = this.state.columns[draggedIndex];
        const newColumns: IColumn[] = [...this.state.columns];

        // insert before the dropped item
        newColumns.splice(draggedIndex, 1);
        newColumns.splice(targetIndex, 0, draggedItems);
        this.setState({ columns: newColumns });
    };

    private _getColumnReorderOptions(): IColumnReorderOptions {
        return {
            frozenColumnCountFromStart: parseInt(this.state.frozenColumnCountFromStart, 10),
            frozenColumnCountFromEnd: parseInt(this.state.frozenColumnCountFromEnd, 10),
            handleColumnReorder: this._handleColumnReorder,
        };
    }

    private _validateNumber(value: string): string {
        return isNaN(Number(value)) ? `The value should be a number, actual is ${value}.` : '';
    }

    private _onChangeStartCountText = (
        event: React.FormEvent<HTMLInputElement | HTMLTextAreaElement>,
        text: string | undefined,
    ): void => {
        this.setState({ frozenColumnCountFromStart: text || '' });
    };

    private _onChangeEndCountText = (
        event: React.FormEvent<HTMLInputElement | HTMLTextAreaElement>,
        text: string | undefined,
    ): void => {
        this.setState({ frozenColumnCountFromEnd: text || '' });
    };

    private _onChangeColumnReorderEnabled = (ev: React.MouseEvent<HTMLElement>, checked: boolean | undefined): void => {
        this.setState({ isColumnReorderEnabled: checked || false });
    };

    private _getDragDropEvents(): IDragDropEvents {
        return {
            canDrop: (dropContext?: IDragDropContext, dragContext?: IDragDropContext) => {
                return true;
            },
            canDrag: (item?: any) => {
                return true;
            },
            onDragEnter: (item?: any, event?: DragEvent) => {
                // return string is the css classes that will be added to the entering element.
                return this.dragEnterClass;
            },
            onDragLeave: (item?: any, event?: DragEvent) => {
                return;
            },
            onDrop: (item?: any, event?: DragEvent) => {
                if (this._draggedItem) {
                    this._insertBeforeItem(item);
                }
            },
            onDragStart: (item?: any, itemIndex?: number, selectedItems?: any[], event?: MouseEvent) => {
                this._draggedItem = item;
                this._draggedIndex = itemIndex!;
            },
            onDragEnd: (item?: any, event?: DragEvent) => {
                this._draggedItem = undefined;
                this._draggedIndex = -1;
            },
        };
    }

    private _onItemInvoked = (item: ITableItem): void => {
        alert(`Item invoked: ${item.id}`);
    };

    private _onRenderItemColumn = (
        item: ITableItem,
        index: number | undefined,
        column: IColumn | undefined,
    ): JSX.Element | string => {
        const key = column && (column.key as keyof ITableItem);
        if (key === 'id') {
            return <Link data-selection-invoke={true}>{item[key]}</Link>;
        }

        return (
            <TableItem
                itemId={item.itemId}
                id={item.id}
                dueDate={item.dueDate.toDateString()}
                priority={item.priority}
            ></TableItem>
        );
    };

    private _buildColumns(items: ITableItem[]): IColumn[] {
        const itemIds = items.map(itm => itm.id);
        // or no header
        const columns = buildColumns(itemIds).map(clm => {
            return { ...clm, name: '' };
        });

        // const thumbnailColumn = columns.filter(column => column.name === 'thumbnail')[0];

        // Special case one column's definition.
        // thumbnailColumn.name = '';
        // thumbnailColumn.maxWidth = 50;

        return columns;
    }

    private _renderItemColumn(item: ITableItem, index: number | undefined, column: IColumn | undefined) {
        const fieldContent = item[column!.fieldName as keyof ITableItem] as string;

        debugger;

        switch (column!.key) {
            // case 'itemId':
            //     return <Image width={50} height={50} imageFit={ImageFit.cover} />;

            // case 'id':
            //     return <Link href="#">{fieldContent}</Link>;

            // case 'color':
            //     return (
            //         <span
            //             data-selection-disabled={true}
            //             className={mergeStyles({
            //                 color: fieldContent,
            //                 height: '100%',
            //                 display: 'block',
            //             })}
            //         >
            //             {fieldContent}
            //         </span>
            //     );

            default:
                return <span>{fieldContent}</span>;
        }
    }

    private _insertBeforeItem(item: ITableItem): void {
        const draggedItems = this._selection.isIndexSelected(this._draggedIndex)
            ? (this._selection.getSelection() as ITableItem[])
            : [this._draggedItem!];

        const items = this.state.items.filter(itm => draggedItems.indexOf(itm) === -1);
        let insertIndex = items.indexOf(item);

        // if dragging/dropping on itself, index will be 0.
        if (insertIndex === -1) {
            insertIndex = 0;
        }

        items.splice(insertIndex, 0, ...draggedItems);

        this.setState({ items: items });
    }
}
