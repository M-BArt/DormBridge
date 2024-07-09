<template>
  <div class="q-ml-md q-mr-md">
    <q-table virtual-scroll dark flat bordered title="Rooms" :rows="rows" :columns="columns" row-key="name" class="asd my-sticky-virtscroll-table">
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>
          <q-td key="calories" :props="props">
            <q-badge color="green">
              {{ props.row.calories }}
            </q-badge>
          </q-td>
          <q-td key="fat" :props="props">
            <q-badge color="purple">
              {{ props.row.fat }}
            </q-badge>
          </q-td>
          <q-td key="carbs" :props="props">
            <q-badge color="orange">
              {{ props.row.carbs }}
            </q-badge>
          </q-td>
          <q-td key="protein" :props="props">
            <q-badge color="primary">
              {{ props.row.protein }}
            </q-badge>
          </q-td>
          <q-td key="sodium" :props="props">
            <q-badge color="teal">
              {{ props.row.sodium }}
            </q-badge>
          </q-td>
          <q-td key="calcium" :props="props">
            <q-badge color="accent">
              {{ props.row.calcium }}
            </q-badge>
          </q-td>
          <q-td key="iron" :props="props">
            <q-badge color="amber">
              {{ props.row.iron }}
            </q-badge>
          </q-td>
        </q-tr>
      </template>
    </q-table>
  </div>
  <q-card class="row zxc q-pa-none q-ma-md no-shadow flex justify-between">
    <q-card dark class="col-xs-4 col-xl-3 asd flex justify-start q-ml-none q-pa-none no-shadow column" style="border: 1px solid #7466f1">
      <q-card dark class="flex flex-center" style="background-color: #7466f1; height: 25px">Filtrs</q-card>
      <q-select class="q-ma-sm" dark color="white" v-model="model" :options="options" label="Dormitory">
        <template v-if="model" v-slot:append>
          <q-icon name="cancel" @click.stop.prevent="model = null" class="cursor-pointer" />
        </template>
      </q-select>
      <q-select class="q-ma-sm" dark color="white" v-model="model" :options="options" label="Room type">
        <template v-if="model" v-slot:append>
          <q-icon name="cancel" @click.stop.prevent="model = null" class="cursor-pointer" />
        </template>
      </q-select>
      <q-select class="q-ma-sm" dark color="white" v-model="model" :options="options" label="Room area [min]">
        <template v-if="model" v-slot:append>
          <q-icon name="cancel" @click.stop.prevent="model = null" class="cursor-pointer" />
        </template>
      </q-select>
      <q-select multiple class="q-ma-sm" dark color="white" v-model="model" :options="options" label="Cost [max]">
        <template v-if="model" v-slot:append>
          <q-icon name="cancel" @click.stop.prevent="model = null" class="cursor-pointer" />
        </template>
      </q-select>

      <q-select multiple class="q-ma-sm" dark color="white" v-model="modelEq" :options="optionsEq" label="Equipment">
        <template v-if="modelEq" v-slot:append>
          <q-icon name="cancel" @click.stop.prevent="modelEq = null" class="cursor-pointer" />
        </template>
      </q-select>

      <q-item>
        <q-item-section>
          <q-item-label>Internet access</q-item-label>
        </q-item-section>
        <q-item-section side>
          <q-toggle color="blue" v-model="notif1" val="battery" />
        </q-item-section>
      </q-item>

      <q-item>
        <q-item-section>
          <q-item-label>Own bathroom</q-item-label>
        </q-item-section>
        <q-item-section side>
          <q-toggle color="blue" v-model="notif2" val="battery" />
        </q-item-section>
      </q-item>

      <q-btn class="q-ma-sm" style="background: #7466f1; color: white" label="Reset" />
    </q-card>

    <q-card dark class="col-7 flex justify-start q-ma-none q-pa-none no-shadow row" style="border: 2px solid #7466f1">
      <q-card dark class="flex flex-center q-pa-none q-ma-none" style="background-color: #7466f1; width: 100%; height: 25px">Filtrs</q-card>
      <Information header="Basic information" :information="basicInformation" cardWidth="50%" />
      <Information header="Equipment" :information="equipmentInformation" cardWidth="50%" />
      <Information header="Other information" :information="otherInformation" cardWidth="100%" />
    </q-card>
  </q-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Information from 'components/InformationPanel.vue';

interface TableColumn {
  name: string;
  label: string;
  field: string | ((row: any) => any);
  required?: boolean;
  align?: 'left' | 'center' | 'right';
  sortable?: boolean;
  sort?: (a: any, b: any, rowA: any, rowB: any) => number;
  format?: (val: string | number) => string;
}
interface RowData {
  name: string;
  calories: number;
  fat: number;
  carbs: number;
  protein: number;
  sodium: number;
  calcium: string;
  iron: string;
}

type Option = 'Google' | 'Facebook' | 'Twitter' | 'Apple' | 'Oracle' | null;
type Options = 'Refrigerator' | 'Microwave' | 'Heating' | 'Air conditioning' | null;
const notif1 = ref(false);
const notif2 = ref(false);
const model = ref<Option>('Google');
const modelEq = ref<Options>(null);

const options: Option[] = ['Google', 'Facebook', 'Twitter', 'Apple', 'Oracle'];
const optionsEq: Options[] = ['Refrigerator', 'Microwave', 'Heating', 'Air conditioning'];

const columns = ref<TableColumn[]>([
  {
    name: 'name',
    required: true,
    label: 'Dessert (100g serving)',
    align: 'left',
    field: (row: RowData) => row.name,
    format: (val: string | number) => `${val}`,
    sortable: true,
  },
  { name: 'calories', align: 'center', label: 'Calories', field: 'calories', sortable: true },
  { name: 'fat', label: 'Fat (g)', field: 'fat', sortable: true },
  { name: 'carbs', label: 'Carbs (g)', field: 'carbs' },
  { name: 'protein', label: 'Protein (g)', field: 'protein' },
  { name: 'sodium', label: 'Sodium (mg)', field: 'sodium' },
  {
    name: 'calcium',
    label: 'Calcium (%)',
    field: 'calcium',
    sortable: true,
    sort: (a: RowData, b: RowData) => parseInt(a.calcium, 10) - parseInt(b.calcium, 10),
  },
  { name: 'iron', label: 'Iron (%)', field: 'iron', sortable: true, sort: (a: RowData, b: RowData) => parseInt(a.iron, 10) - parseInt(b.iron, 10) },
]);
const rows = ref<RowData[]>([
  {
    name: 'Frozen Yogurt',
    calories: 159,
    fat: 6.0,
    carbs: 24,
    protein: 4.0,
    sodium: 87,
    calcium: '14%',
    iron: '1%',
  },
  {
    name: 'Frozen Yogurt',
    calories: 159,
    fat: 6.0,
    carbs: 24,
    protein: 4.0,
    sodium: 87,
    calcium: '14%',
    iron: '1%',
  },
  {
    name: 'Frozen Yogurt',
    calories: 159,
    fat: 6.0,
    carbs: 24,
    protein: 4.0,
    sodium: 87,
    calcium: '14%',
    iron: '1%',
  },
  {
    name: 'Ice cream sandwich',
    calories: 237,
    fat: 9.0,
    carbs: 37,
    protein: 4.3,
    sodium: 129,
    calcium: '8%',
    iron: '1%',
  },
  {
    name: 'Eclair',
    calories: 262,
    fat: 16.0,
    carbs: 23,
    protein: 6.0,
    sodium: 337,
    calcium: '6%',
    iron: '7%',
  },
  {
    name: 'Cupcake',
    calories: 305,
    fat: 3.7,
    carbs: 67,
    protein: 4.3,
    sodium: 413,
    calcium: '3%',
    iron: '8%',
  },
  {
    name: 'Gingerbread',
    calories: 356,
    fat: 16.0,
    carbs: 49,
    protein: 3.9,
    sodium: 327,
    calcium: '7%',
    iron: '16%',
  },
  {
    name: 'Jelly bean',
    calories: 375,
    fat: 0.0,
    carbs: 94,
    protein: 0.0,
    sodium: 50,
    calcium: '0%',
    iron: '0%',
  },
  {
    name: 'Lollipop',
    calories: 392,
    fat: 0.2,
    carbs: 98,
    protein: 0,
    sodium: 38,
    calcium: '0%',
    iron: '2%',
  },
  {
    name: 'Honeycomb',
    calories: 408,
    fat: 3.2,
    carbs: 87,
    protein: 6.5,
    sodium: 562,
    calcium: '0%',
    iron: '45%',
  },
  {
    name: 'Donut',
    calories: 452,
    fat: 25.0,
    carbs: 51,
    protein: 4.9,
    sodium: 326,
    calcium: '2%',
    iron: '22%',
  },
  {
    name: 'KitKat',
    calories: 518,
    fat: 26.0,
    carbs: 65,
    protein: 7,
    sodium: 54,
    calcium: '12%',
    iron: '6%',
  },
]);

interface Information {
  label: string;
  value: string;
}

const basicInformation = ref<Information[]>([
  {
    label: 'Dormitory',
    value: 'Value',
  },
  {
    label: 'Room area',
    value: 'Value',
  },
  {
    label: 'Room type',
    value: 'Value',
  },
  {
    label: 'Number of residents',
    value: 'Value',
  },
  {
    label: 'Number of available places',
    value: 'Value',
  },
  {
    label: 'Cost',
    value: 'Value',
  },
]);

const equipmentInformation = ref<Information[]>([
  {
    label: 'Refrigerator',
    value: 'Value',
  },
  {
    label: 'Microwave',
    value: 'Value',
  },
  {
    label: 'Internet access',
    value: 'Value',
  },
  {
    label: 'Air conditioning',
    value: 'Value',
  },
  {
    label: 'Heating',
    value: 'Value',
  },
  {
    label: 'Bathroom',
    value: 'Value',
  },
]);

const otherInformation = ref<Information[]>([
  {
    label: 'Room number',
    value: 'Value',
  },
  {
    label: 'Floor',
    value: 'Value',
  },
]);
</script>

<style lang="scss">
.my-sticky-virtscroll-table {
  height: 40%;
  border: NONE;
  .q-table__top {
    background-color: #7466f1;
  }

  thead tr:last-child th {
    top: 48px;
  }
  thead tr:first-child th {
    top: 0;
  }
  tbody {
    scroll-margin-top: 48px;
  }
}
</style>
