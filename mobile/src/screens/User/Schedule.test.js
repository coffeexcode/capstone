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

  it('should render the Agenda', () => {
    const comp = render(<Schedule />);
    const agenda = comp.getByTestId('agenda');
    expect(agenda.type).toBe('View');
  })

  it('should navigate to the selected event when pressed', () => {
    const navigation = {
      navigate: jest.fn()
    }
    const comp = render(<Schedule navigation={navigation} />);
    const event = comp.getAllByTestId('scheduleItem');


    fireEvent(event[0], 'press');

    expect(navigation.navigate).toHaveBeenCalled();
  })

  it('should fetch the expected response from the API', () => {
    const comp = render(<Schedule />);
    expect(fetch).toHaveBeenCalled();
  })
})