import React, { Component } from 'react';
import styles from './new-order.scss';
import {
    TextField,
    MaskedTextField,
    DefaultButton,
    PrimaryButton,
    Dropdown,
    IDropdownStyles,
    IDropdownOption,
    DropdownMenuItemType,
} from 'office-ui-fabric-react';
import InlineCalendar from '../../common/components/inline-calendar.component';
import CustomerTag from '../../common/components/customer-tag.component';

interface Props {}
interface State {}

export default class NewOrderComponent extends Component<Props, State> {
    state = {};

    dropdownStyles: Partial<IDropdownStyles> = {
        // dropdown: { width: 300 },
    };

    options: IDropdownOption[] = [
        { key: 'Duration', text: 'hours', itemType: DropdownMenuItemType.Header },
        { key: '0', text: '0-2 hours' },
        { key: '2', text: '2-4 hours' },
        { key: '4', text: '4-6 hours' },
        { key: '6', text: '6-8 hours' },
        { key: 'divider', text: '-', itemType: DropdownMenuItemType.Divider },
        { key: 'header', text: 'more than 8 hours', itemType: DropdownMenuItemType.Header },
        { key: '8', text: '8-10 hours' },
        { key: '10', text: '10-12 hours' },
        { key: '12', text: '12-14 hours' },
        { key: '14', text: '14-16 hours' },
    ];

    render(): JSX.Element {
        return (
            <section id={styles.container}>
                <header id={styles.header}>
                    <div id={styles.banner}>
                        <p>Create Order</p>
                    </div>
                </header>
                <main id={styles.form}>
                    <ul>
                        {/* <li>
                            <TextField prefix="First name:" required />
                        </li>
                        <li>
                            <TextField label="Last name:" underlined />
                        </li> */}
                        <li>
                            {/* <TextField placeholder="Customer" required /> */}
                            <CustomerTag placeholder="Customer" />
                        </li>
                        <li>
                            <TextField placeholder="Office" defaultValue="Portugal1" disabled />
                        </li>
                        <li>
                            <TextField placeholder="Cloth" defaultValue="Short" disabled />
                        </li>
                        <li>
                            <Dropdown
                                placeholder="Duration"
                                defaultSelectedKey="broccoli"
                                options={this.options}
                                styles={this.dropdownStyles}
                            />
                        </li>
                        <li>
                            <InlineCalendar placeholder="Delivery At" />
                        </li>

                        <li>
                            <DefaultButton
                                text="Cancel"
                                onClick={() => {
                                    void 0;
                                }}
                                allowDisabledFocus
                                disabled={false}
                                checked={true}
                            />
                            <PrimaryButton
                                text="Ok"
                                onClick={() => {
                                    void 0;
                                }}
                                allowDisabledFocus
                                disabled={false}
                                checked={true}
                            />
                        </li>
                    </ul>
                </main>
            </section>
        );
    }
}
