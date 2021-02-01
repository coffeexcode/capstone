import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import Sponsors from '@screens/Attendee/Sponsors';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<Sponsors/>', () => {
  it('should render the View properly', () => {
    const tree = render(<Sponsors />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should render a list of sponsors', () => {
    const comp = render(<Sponsors />);
    const list = comp.getByTestId('sponsorList');
    expect(list.props.data.length).toBeGreaterThan(0);
  })

  it('should navigate to the Contact screen when a sponsor is selected', () => {
    const navigation = {
      navigate: jest.fn()
    }
    const comp = render(<Sponsors navigation={navigation} />);
    const list = comp.getByTestId('sponsorList');
    
    const firstItem = list.props.data[0];

    const item = comp.getByTestId(`item-${firstItem.id}`);

    fireEvent(item, 'press');

    expect(navigation.navigate).toHaveBeenCalledWith('Contact', { item: firstItem });
  })
})
