import React, { useEffect, useState } from 'react';
import { FlatList, StyleSheet, TouchableOpacity, View, Modal } from 'react-native';
import { MaterialCommunityIcons } from '@expo/vector-icons';

import CAText from '@core/CAText';
import appText from '@utils/text';

import data from '@data/data.json';

export default function Sponsors({ navigation }) {
  const [sponsors, setSponsors] = useState([]);

  useEffect(() => {
    setSponsors(data['sponsors']);
  });

  const renderIcon = type => {
    switch (type) {
      case 'Bronze':
        return <MaterialCommunityIcons name="podium-bronze" size={24} color="#cd7f32" />
      case 'Silver':
       return <MaterialCommunityIcons name="podium-silver" size={24} color="#C0C0C0" />
      case 'Gold':
        return <MaterialCommunityIcons name="podium-gold" size={24} color="#FFD700" />
      default:
        return <MaterialCommunityIcons name="border-none-variant" size={24} color="black" />
    }
  }

  const renderItem = ({ item }) => (
    <TouchableOpacity
      style={styles.sponsorItem}
      onPress={() => navigation.navigate('Contact', { item: item })}
      >
      <View style={{ flexDirection: 'row', justifyContent: 'center'}}>
        <CAText size='md' style={styles.sponsorName}>{item.name} </CAText>
        {renderIcon(item.type)}
      </View>
    </TouchableOpacity>
  );

  return (
    <View style={styles.container}>
      <View style={styles.heading}>
        <CAText size='sm'>{appText.sponsorType}</CAText>
      </View>
      <View style={styles.infoContainer}>
        <View style={{ width: '25%'}}>
          <CAText size='xsm'>
            {appText.bronze}
            <MaterialCommunityIcons name="podium-bronze" size={24} color="#cd7f32" />
          </CAText>
        </View>
        <View style={{ width: '25%'}}>
          <CAText size='xsm'>
            {appText.silver}
            <MaterialCommunityIcons name="podium-silver" size={24} color="#C0C0C0" />
          </CAText>
        </View>
        <View style={{ width: '25%'}}>
          <CAText size='xsm'>
            {appText.gold}
            <MaterialCommunityIcons name="podium-gold" size={24} color="#FFD700" />
          </CAText>
        </View>
      </View>
      <View style={styles.sponsorContainer}>
      <FlatList
          data={sponsors}
          renderItem={renderItem}
          keyExtractor={sponsor => sponsor.id}
        />
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  title: {
    marginTop: 30,
    alignSelf: 'center'
  },
  heading: {
    padding: 20
  },
  infoContainer: {
    flexDirection: 'row',
    justifyContent: 'center',
    borderBottomColor: 'black',
    borderBottomWidth: 0.5,
    paddingBottom: 30
  },
  sponsorContainer: {
    flex: 1,
    alignContent: 'center',
  },
  sponsorItem: {
    flex: 1,
    padding: 12,
    borderBottomColor: 'black',
    borderBottomWidth: 0.25
  },
  sponsorName: {
    width: '90%',
    paddingVertical: 10,
    fontWeight: '300'
  }
});
