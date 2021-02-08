import React from 'react';
import { render } from '@testing-library/react-native';
import ScanQR from '@screens/Organizer/ScanQR';

jest.useFakeTimers();
jest.mock('expo-permissions');

/**
 * This component has been left out of most of the testing since unit testing does not 
 * cover any of the functionality done by using the app camera. Jest has no support for 
 * this, for good reason. The bar code scanner can only be tested by a physical device.
 */
describe('<ScanQR/>', () => {
  it('should render the QR Scanner properly [ACCEPTANCE TEST (F-28)]', () => {
    const tree = render(<ScanQR/>).toJSON();
    expect(tree.type).toBe('View');
  })
})
