import React from 'react';
import { render } from '@testing-library/react-native';

import Spacer from '@core/Spacer';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<Spacer/>', () => {
  it('renders the View properly', () => {
    const tree = render(<Spacer/>).toJSON();
    expect(tree.type).toBe('View');
  })

  it('renders the spacer with the proper specified size', () => {
    const testProps = {
      size: 'lg',
      height: 40
    };
    const expectedHeight = { height: 40 };

    const comp = render(<Spacer testID='test' size={testProps.size}/>);
    const spacer = comp.getByTestId('test');
    
    expect(spacer.props.style[1]).toStrictEqual(expectedHeight);
  })
});
