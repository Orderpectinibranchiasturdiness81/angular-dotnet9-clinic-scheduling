import { Component, OnInit } from '@angular/core';

interface MenuItem {
  name: string;
  url?: string;
  icon?: string;
  children: MenuItem[];
  open?: boolean; // To control the collapse state
}

@Component({
  selector: 'app-menu',
  standalone: false,
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  menuItems: MenuItem[] = [];

  constructor() { }

  ngOnInit(): void {
    this.menuItems = this.getMenuItems();
  }

  getMenuItems(): MenuItem[] {
    return [
      {
        name: 'Dashboard',
        icon: 'fa fa-tachometer-alt',
        url: '/dashboard',
        children: []
      },
      {
        name: 'Users',
        icon: 'fa fa-users',
        children: [
          { name: 'Manage Users', url: '/users/manage', children: [] },
          { name: 'Add User', url: '/users/add', children: [] }
        ]
      },
      {
        name: 'Settings',
        icon: 'fa fa-cogs',
        children: [
          { name: 'General', url: '/settings/general', children: [] },
          { name: 'Security', url: '/settings/security', children: [] }
        ]
      },
      {
        name: 'User Profiles',
        icon: 'fa fa-cogs',
        children: [
          { name: 'Search User Profiles', url: '/user-profile', children: [] },
          { name: 'Add User Profiles', url: '/user-profile/manage', children: [] },
        ]
      }
    ];
  }

  toggleDropdown(item: MenuItem): void {
    item.open = !item.open;
  }

  isOpen(item: MenuItem): boolean {
    return item.open ?? false;
  }
}
