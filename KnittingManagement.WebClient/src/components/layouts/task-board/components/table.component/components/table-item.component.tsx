import React, { Component } from 'react';
import styles from './table-item.scss';
import { ITableItem } from '../contracts/ITableItem';

interface Props {
    dueDate: string;
    priority: number;
    itemId: string;
    id: string;
}
interface State {}

export class TableItem extends Component<Props, State> {
    state = {};

    render() {
        const props = this.props;

        return (
            <div id={styles.container}>
                <div>
                    <p>code</p>
                    <div></div>
                </div>
                <div>
                    <p>info</p>
                    <ul>
                        <li>{props.dueDate}</li>
                        <li>{props.itemId}</li>
                        <li>{props.priority}</li>
                        <li>{props.id}</li>
                    </ul>
                </div>
            </div>
        );
    }
}
