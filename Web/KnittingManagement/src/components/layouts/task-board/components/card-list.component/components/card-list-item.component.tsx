import React, { Component, useState, useEffect } from 'react';
import {
    Card,
    ICardTokens,
    ICardSectionStyles,
    ICardSectionTokens,
    ICardStyles,
    ICardItemStyles,
} from '@uifabric/react-cards';
// import { ICardSectionTokens } from 'office-ui-fabric-react/lib/Link';
import { FontWeights } from '@uifabric/styling';
import { Icon, IIconStyles, Image, Stack, IStackTokens, Text, ITextStyles, IStackStyles } from 'office-ui-fabric-react';
import { ImageFactoryService } from '../../../../../../services/image-factory.service';
import styles from './card-list-item.scss';
import { useId } from '@uifabric/react-hooks';
import {
    TooltipHost,
    TooltipDelay,
    DirectionalHint,
    ITooltipProps,
    ITooltipHostStyles,
} from 'office-ui-fabric-react/lib/Tooltip';
interface Props {
    id: string;
}
interface State {
    image: string | undefined;
}

// export function useScreenWidth(): number {
//     const [width, setWidth] = useState(window.innerWidth);

//     useEffect(() => {
//         const handler = (event: any) => {
//             setWidth(event.target.innerWidth);
//         };

//         window.addEventListener('resize', handler);

//         return () => {
//             window.removeEventListener('resize', handler);
//         };
//     }, []);

//     return width;
// }

export const withHooksHOC: any = (Component: any): any => {
    return (props: any) => {
        var id = useId();
        return <Component id={id} {...props} />;
    };
};

export class CardListItemComponent extends Component<Props, State> {
    state = {
        image: undefined,
    };

    alertClicked = (): void => {
        alert('Clicked');
    };

    constructor(props: Props) {
        super(props);
    }

    public async componentDidMount() {
        new ImageFactoryService().tryGetImageAsync(6, 130).subscribe(image => {
            debugger;
            this.setState({ image });
        });
    }

    card: ICardStyles = {
        root: {
            height: '140px',
            display: 'flex',
            width: '100%',
            alignItems: 'stretch',
            maxWidth: '100%',
            outline: 'none',
            boxShadow: '0px 0px 4px 2px rgba(232,232,232,1);',
        },
    };
    stack: IStackStyles = {
        root: {
            height: '140px',
            display: 'flex',
            width: '100%',
            alignItems: 'stretch',
        },
    };
    CardSectionStyles: ICardItemStyles = {
        root: {
            width: '100%',
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'space-between',
        },
    };

    CardItemStyles: ICardItemStyles = {
        root: {
            position: 'relative',
            height: '140px',
        },
    };
    siteTextStyles: ITextStyles = {
        root: {
            color: '#025F52',
            fontWeight: FontWeights.semibold,
        },
    };
    descriptionTextStyles: ITextStyles = {
        root: {
            color: '#333333',
            fontWeight: FontWeights.regular,
        },
    };
    helpfulTextStyles: ITextStyles = {
        root: {
            color: '#333333',
            fontWeight: FontWeights.regular,
            display: 'flex',
            alignItems: 'center',
            padding: '0 2px',
            justifyContent: 'flex-start',
            selectors: {
                'div > p': { padding: 0, margin: 0, textAlign: 'end' },
            },
        },
    };
    iconStyles: IIconStyles = {
        root: {
            color: '#0078D4',
            fontSize: 16,
            fontWeight: FontWeights.regular,
        },
    };
    footerCardSectionStyles: ICardSectionStyles = {
        root: {
            alignSelf: 'stretch',
            borderLeft: '1px solid #F3F2F1',
        },
    };

    sectionStackTokens: IStackTokens = { childrenGap: 20 };
    cardTokens: ICardTokens = { childrenMargin: 12 };
    footerCardSectionTokens: ICardSectionTokens = { padding: '0px 0px 0px 12px' };

    tooltipProps: ITooltipProps = {
        onRenderContent: () => (
            // <ul style={{ margin: 10, padding: 0 }}>
            //     <li>1. One</li>
            //     <li>2. Two</li>
            // </ul>
            <span>Created at</span>
        ),
    };

    hostStyles: Partial<ITooltipHostStyles> = {
        root: {
            display: 'inline-block',
        },
    };
    // tooltipId = useId('tooltip');

    public render(): JSX.Element {
        return (
            <div id={styles.container}>
                <Stack
                    // styles={this.stack}
                    tokens={this.sectionStackTokens}
                >
                    <Card
                        aria-label="Clickable horizontal card "
                        horizontal
                        styles={this.card}
                        // onClick={this.alertClicked}
                        tokens={this.cardTokens}
                    >
                        <Card.Item fill styles={this.CardItemStyles}>
                            <div className={styles.cardItemNumber}>
                                <span>09463</span>
                            </div>
                            {this.state.image === undefined ? (
                                <div className={styles.cardItem}></div>
                            ) : (
                                <div
                                    className={styles.cardItem}
                                    dangerouslySetInnerHTML={{ __html: this.state.image! }}
                                />
                            )}
                        </Card.Item>
                        <Card.Section styles={this.CardSectionStyles}>
                            <div className={styles.cardSection}>
                                <ul>
                                    <li>
                                        <p>Due Date:</p>
                                        <div className={styles.dueDate}>
                                            <div className={styles.cardSectionPriority}>
                                                <p>normal</p>
                                            </div>
                                            <p>20 / 20 / 2020</p>
                                        </div>
                                    </li>
                                    <li>
                                        <p>Customer:</p>
                                        <p>Bravo J.</p>
                                    </li>
                                </ul>
                            </div>
                            <div className={styles.created}>
                                <TooltipHost
                                    tooltipProps={this.tooltipProps}
                                    delay={TooltipDelay.zero}
                                    calloutProps={{ gapSpace: 0 }}
                                    id={this.props.id}
                                    directionalHint={DirectionalHint.rightTopEdge}
                                    styles={this.hostStyles}
                                >
                                    <Text
                                        variant="small"
                                        aria-describedby={this.props.id}
                                        styles={this.helpfulTextStyles}
                                    >
                                        <div>
                                            <p>14:00</p>
                                            <p>Monday Jun</p>
                                        </div>
                                    </Text>
                                </TooltipHost>
                            </div>
                        </Card.Section>
                        <Card.Section styles={this.footerCardSectionStyles} tokens={this.footerCardSectionTokens}>
                            <Icon iconName="RedEye" styles={this.iconStyles} />
                            <Icon iconName="SingleBookmark" styles={this.iconStyles} />
                            <Stack.Item grow={1}>
                                <span />
                            </Stack.Item>
                            <Icon iconName="MoreVertical" styles={this.iconStyles} />
                        </Card.Section>
                    </Card>
                </Stack>
                {/* <Stack tokens={this.sectionStackTokens}>
                    <Card
                        aria-label="Clickable horizontal card "
                        horizontal
                        styles={this.card}
                        onClick={this.alertClicked}
                        tokens={this.cardTokens}
                    >
                        <Card.Item fill styles={this.CardItemStyles}>
                            {this.state.image === undefined ? (
                                <div className={styles.cardItem}></div>
                            ) : (
                                <div
                                    className={styles.cardItem}
                                    dangerouslySetInnerHTML={{ __html: this.state.image! }}
                                />
                            )}
                        </Card.Item>
                        <Card.Section>
                            <Text variant="small" styles={this.siteTextStyles}>
                                Contoso
                            </Text>{' '}
                            <Text styles={this.descriptionTextStyles}>
                                Contoso Denver expansion design marketing hero guidelines
                            </Text>
                            <Text variant="small" styles={this.helpfulTextStyles}>
                                Is this recommendation helpful?
                            </Text>
                        </Card.Section>
                        <Card.Section styles={this.footerCardSectionStyles} tokens={this.footerCardSectionTokens}>
                            <Icon iconName="RedEye" styles={this.iconStyles} />
                            <Icon iconName="SingleBookmark" styles={this.iconStyles} />
                            <Stack.Item grow={1}>
                                <span />
                            </Stack.Item>
                            <Icon iconName="MoreVertical" styles={this.iconStyles} />
                        </Card.Section>
                    </Card>
                </Stack> */}
            </div>
        );
    }
}

export default withHooksHOC(CardListItemComponent);
