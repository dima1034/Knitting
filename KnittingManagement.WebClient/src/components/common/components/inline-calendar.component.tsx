import React, { Component } from 'react';
import { Dropdown, IDropdownOption } from 'office-ui-fabric-react/lib/Dropdown';
import { DatePicker, DayOfWeek, IDatePickerStrings, mergeStyleSets, initializeIcons } from 'office-ui-fabric-react';

interface Props {
    placeholder: string;
}
interface State {
    firstDayOfWeek?: DayOfWeek;
}

export default class InlineCalendar extends Component<Props, State> {
    public constructor(props: { placeholder: string }) {
        super(props);

        this.state = {
            firstDayOfWeek: DayOfWeek.Sunday,
        };
    }

    DayPickerStrings: IDatePickerStrings = {
        months: [
            'January',
            'February',
            'March',
            'April',
            'May',
            'June',
            'July',
            'August',
            'September',
            'October',
            'November',
            'December',
        ],

        shortMonths: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],

        days: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],

        shortDays: ['S', 'M', 'T', 'W', 'T', 'F', 'S'],

        goToToday: 'Go to today',
        prevMonthAriaLabel: 'Go to previous month',
        nextMonthAriaLabel: 'Go to next month',
        prevYearAriaLabel: 'Go to previous year',
        nextYearAriaLabel: 'Go to next year',
        closeButtonAriaLabel: 'Close date picker',
    };

    controlClass = mergeStyleSets({
        control: {
            // margin: '0 0 15px 0',
            // maxWidth: '300px',
        },
    });

    render() {
        const { firstDayOfWeek } = this.state;
        return (
            <DatePicker
                // className={this.controlClass.control}
                firstDayOfWeek={firstDayOfWeek}
                strings={this.DayPickerStrings}
                placeholder={this.props.placeholder}
                // ariaLabel="Select a date"
            />
        );
    }
}
