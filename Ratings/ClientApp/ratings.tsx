import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Ratings extends React.Component<any, any> {
    userRating() {
        if (this.props.rating.userRating) {
            return <div className="imdb">User Rating: {this.props.rating.userRating}</div>;
        }

        return null;
    }

    public render() {
        if (this.props.rating.loading) {
            return <div><i>Loading...</i></div>;
        }

        return <div className="rating">
            <div className="imdb">IMDB Rating: {this.props.rating.imdbRating}</div>
            {this.userRating()}
        </div>;
    }
}