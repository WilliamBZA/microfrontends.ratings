import * as React from 'react';
import { RouteComponentProps } from 'react-router';

import { Ratings } from '../ratings';

export class Home extends React.Component<RouteComponentProps<{}>, any> {
    constructor() {
        super();

        this.state = {
            rating: {
                loading: false,
                imdbRating: '1/7'
            }
        };
    }

    public render() {
        return <div>
            <Ratings rating={this.state.rating} />
        </div>;
    }
}
