import React, { Component } from 'react';
import styles from './task-board.scss';
import TableComponent from './components/table.component/table.component';

interface Props {}
interface State {}

export default class TaskBoardComponent extends Component<Props, State> {
    state = {};

    // service call to get all items

    render() {
        return (
            <section id={styles.container}>
                <header id={styles.header}>
                    <div id={styles.banner}>
                        <p>Board</p>
                    </div>
                </header>
                <main id={styles.main}>
                    {/* other divs */}
                    <div id={styles.table}>
                        <div className={styles.tableColumn}>
                            <TableComponent key={'1'} title="New" items={[]}></TableComponent>
                        </div>
                        <div className={styles.tableColumn}>
                            <TableComponent key={'2'} title="InProgress" items={[]}></TableComponent>
                        </div>
                        <div className={styles.tableColumn}>
                            <TableComponent key={'3'} title="Done" items={[]}></TableComponent>
                        </div>
                    </div>
                </main>
            </section>
        );
    }
}
