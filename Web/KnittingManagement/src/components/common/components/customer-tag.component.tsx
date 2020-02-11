import React, { Component } from 'react';
import { TagPicker, IBasePicker, ITag } from 'office-ui-fabric-react/lib/Pickers';
import { mergeStyles } from 'office-ui-fabric-react/lib/Styling';

interface Props {
    placeholder: string;
}
interface State {
    isPickerDisabled?: boolean;
}

export default class CustomerTag extends Component<Props, State> {
    private _picker = React.createRef<IBasePicker<ITag>>();

    constructor(props: { placeholder: string }) {
        super(props);
        this.state = {
            isPickerDisabled: false,
        };
    }

    rootClass = mergeStyles({
        // maxWidth: 500,
    });

    _testTags: ITag[] = [
        'black',
        'blue',
        'brown',
        'cyan',
        'green',
        'magenta',
        'mauve',
        'orange',
        'pink',
        'purple',
        'red',
        'rose',
        'violet',
        'white',
        'yellow',
    ].map(item => ({ key: item, name: item }));

    private _getTextFromItem(item: ITag): string {
        return item.name;
    }

    private _onDisabledButtonClick = (): void => {
        this.setState({
            isPickerDisabled: !this.state.isPickerDisabled,
        });
    };

    private _onFilterChanged = (filterText: string, selectedItems: ITag[] | undefined): ITag[] => {
        return filterText
            ? this._testTags
                  .filter(tag => tag.name.toLowerCase().indexOf(filterText.toLowerCase()) === 0)
                  .filter(tag => !this._listContainsDocument(tag, selectedItems))
            : [];
    };

    private _onFilterChangedNoFilter = (filterText: string, tagList: ITag[]): ITag[] => {
        return filterText
            ? this._testTags.filter(tag => tag.name.toLowerCase().indexOf(filterText.toLowerCase()) === 0)
            : [];
    };

    private _onItemSelected = (item: ITag): ITag | null => {
        if (this._picker.current && this._listContainsDocument(item, this._picker.current.items)) {
            return null;
        }
        return item;
    };

    private _listContainsDocument(tag: ITag, tagList?: ITag[]) {
        if (!tagList || !tagList.length || tagList.length === 0) {
            return false;
        }
        return tagList.filter(compareTag => compareTag.key === tag.key).length > 0;
    }

    render() {
        return (
            <TagPicker
                removeButtonAriaLabel="Remove"
                onResolveSuggestions={this._onFilterChanged}
                getTextFromItem={this._getTextFromItem}
                pickerSuggestionsProps={{
                    suggestionsHeaderText: 'Suggested Tags',
                    noResultsFoundText: 'No Customer Tags Found',
                }}
                itemLimit={2}
                disabled={this.state.isPickerDisabled}
                inputProps={{
                    placeholder: this.props.placeholder,
                    onBlur: (ev: React.FocusEvent<HTMLInputElement>) => console.log('onBlur called'),
                    onFocus: (ev: React.FocusEvent<HTMLInputElement>) => console.log('onFocus called'),
                    'aria-label': 'Tag Picker',
                }}
            />
        );
    }
}
