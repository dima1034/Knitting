import React, { Component } from 'react';
import styles from './new-order.scss';

interface Props {}
interface State {}

export default class NewOrderComponent extends Component<Props, State> {
    state = {};

    render(): JSX.Element {
        return <div className={styles.app}>Hello App!</div>;
    }
}
