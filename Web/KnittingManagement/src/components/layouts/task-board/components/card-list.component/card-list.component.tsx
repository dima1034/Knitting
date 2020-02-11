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
    ISelectionZoneProps,
    IDetailsListStyles,
    SelectionMode,
} from 'office-ui-fabric-react/lib/DetailsList';
import { MarqueeSelection } from 'office-ui-fabric-react/lib/MarqueeSelection';
import { TextField, ITextFieldStyles } from 'office-ui-fabric-react/lib/TextField';
import { Toggle } from 'office-ui-fabric-react/lib/Toggle';
import { getTheme, mergeStyles } from 'office-ui-fabric-react/lib/Styling';
import { Image, ImageFit } from 'office-ui-fabric-react';
import CardListItemComponent from './components/card-list-item.component';

interface Props {
    title: string;
}
interface State {}

export default class CardListComponent extends Component<Props, State> {
    customStyles: Partial<IDetailsListStyles> = {
        root: {
            backgroundColor: 'red',
            padding: 0,
            margin: 0,
            columnRuleColor: 'red',
            animation: 'none',
            textOverlineColor: 'red',
        },
        focusZone: {
            backgroundColor: ' green',
        },
        contentWrapper: {
            backgroundColor: 'yellow',
            animation: 'none',
        },
        headerWrapper: {
            backgroundColor: 'red',
        },
    };

    state: State = {
        items: [] as any,
        columns: [] as any,
        isColumnReorderEnabled: true,
        frozenColumnCountFromStart: '',
        frozenColumnCountFromEnd: '',
    };

    constructor(props: Props) {
        super(props);

        this.state = {};
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

    render() {
        const { title } = this.props;

        return <CardListItemComponent></CardListItemComponent>;
    }
}
