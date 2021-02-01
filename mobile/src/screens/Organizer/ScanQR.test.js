import React from 'react';
import { fireEvent, render, waitFor } from '@testing-library/react-native';
import * as Permissions from 'expo-permissions';

import ScanQR from '@screens/Organizer/ScanQR';

jest.useFakeTimers();
jest.mock('expo-permissions');

describe('<ScanQR/>', () => {
  it('should render the View properly', () => {
    const tree = render(<ScanQR />).toJSON();
    expect(tree.type).toBe('View');
  })

  // it('should render the QR code scanner when permissions are given', async () => {
  //   const comp = await waitFor(() => render(<ScanQR/>));
  // })
})
