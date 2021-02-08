import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import ScanAction from '@screens/Organizer/ScanAction';

jest.useFakeTimers();
jest.mock('@expo/vector-icons');

global.fetch = jest.fn(() => Promise.resolve({}));

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

  it('should request to the API which action was taken [ACCEPTANCE TEST (F-29, F-30)]', () => {
    const comp = render(<ScanAction />);
    expect(fetch).toHaveBeenCalled();
  })
})
