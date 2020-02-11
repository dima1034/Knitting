import React, { Component } from 'react';
import styles from './table-item.scss';
import { ITableItem } from '../contracts/ITableItem';
import { Button } from 'office-ui-fabric-react';
import { CommandBarButton } from 'office-ui-fabric-react/lib/Button';
import { IOverflowSetItemProps, OverflowSet } from 'office-ui-fabric-react/lib/OverflowSet';

interface Props {
    dueDate: string;
    priority: number;
    itemId: string;
    id: string;
}
interface State {}

export class TableItemComponent extends Component<Props, State> {
    state = {};
    noOp = () => undefined;

    render() {
        const props = this.props;

        return (
            <div id={styles.container}>
                <div className={styles.itemCode}>
                    <p>{props.itemId}</p>
                    <img src="/serial-number.png"></img>
                </div>
                <div className={styles.itemDottedSplitter}></div>
                <div className={styles.itemInfo}>
                    <div>
                        <ul>
                            <li>
                                <p>Due Date:</p>
                                <p>{props.dueDate}</p>
                            </li>
                            <li>
                                <p>Priority:</p>
                                <p>{props.priority}</p>
                            </li>
                            <li>
                                <p>Customer:</p>
                                <p>Bravo J.</p>
                            </li>
                            <li>
                                <p>Worker:</p>
                                <p>Miroslava</p>
                            </li>
                            <li>
                                <p>Created:</p>
                                <p>14:00am 20/20/20</p>
                            </li>
                        </ul>
                    </div>
                    <div className={styles.overflowSet}>
                        <OverflowSet
                            aria-label="Vertical Example"
                            role="menubar"
                            vertical
                            items={[
                                {
                                    key: 'item1',
                                    icon: 'Add',
                                    name: 'Link 1',
                                    ariaLabel: 'New. Use left and right arrow keys to navigate',
                                    onClick: this.noOp,
                                },
                                {
                                    key: 'item2',
                                    icon: 'Upload',
                                    name: 'Link 2',
                                    onClick: this.noOp,
                                },
                                {
                                    key: 'item3',
                                    icon: 'Share',
                                    name: 'Link 3',
                                    onClick: this.noOp,
                                },
                            ]}
                            overflowItems={[
                                {
                                    key: 'item4',
                                    icon: 'Mail',
                                    name: 'Overflow Link 1',
                                    onClick: this.noOp,
                                },
                                {
                                    key: 'item5',
                                    icon: 'Calendar',
                                    name: 'Overflow Link 2',
                                    onClick: this.noOp,
                                },
                            ]}
                            onRenderOverflowButton={this._onRenderOverflowButton}
                            onRenderItem={this._onRenderItem}
                        />
                    </div>
                </div>
            </div>
        );
    }
    private _onRenderItem = (item: IOverflowSetItemProps): JSX.Element => {
        return (
            <CommandBarButton
                role="menuitem"
                aria-label={item.name}
                styles={{ root: { padding: '10px', backgroundColor: 'transparent' } }}
                iconProps={{ iconName: item.icon }}
                onClick={item.onClick}
            />
        );
    };

    private _onRenderOverflowButton = (overflowItems: any[] | undefined): JSX.Element => {
        return (
            <CommandBarButton
                role="menuitem"
                title="More items"
                styles={{
                    root: { padding: '10px', backgroundColor: 'transparent' },
                    menuIcon: { fontSize: '16px', backgroundColor: 'transparent' },
                }}
                menuIconProps={{ iconName: 'More' }}
                menuProps={{ items: overflowItems! }}
            />
        );
    };
}
