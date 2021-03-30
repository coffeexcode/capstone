import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import Schedule from '@screens/User/Schedule';

jest.mock('@expo/vector-icons');
jest.mock('react-native/Libraries/Animated/src/NativeAnimatedHelper');
jest.useFakeTimers();

global.fetch = jest.fn(() => Promise.resolve({}));

describe('<Schedule/>', () => {
  it('should render the View properly', () => {
    const tree = render(<Schedule />).toJSON();
    expect(tree.type).toBe('RCTSafeAreaView');
  })

  it('should render the Agenda to view scheduled events [ACCEPTANCE TEST (F-10)]', () => {
    const comp = render(<Schedule />);
    const agenda = comp.getByTestId('agenda');
    expect(agenda.type).toBe('View');
  })
})
