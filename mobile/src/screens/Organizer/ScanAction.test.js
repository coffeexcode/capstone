import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import ScanAction from '@screens/Organizer/ScanAction';

jest.useFakeTimers();

describe('<ScanAction/>', () => {
  it('should render the View properly', () => {
    const tree = render(<ScanAction />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should navigate back to the Scan QR screen when any button is selected', () => {
    const navigation = {
      navigate: jest.fn()
    }
    const comp = render(<ScanAction navigation={navigation} />);
    const button = comp.getByTestId('scanSignBtn');
    fireEvent(button, 'press');

    expect(navigation.navigate).toHaveBeenCalledWith('ScanQR');
  })
})
