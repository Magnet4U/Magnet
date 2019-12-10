package iServicesRemote;

import javax.ejb.Remote;

import entites.User;

@Remote
public  interface  UserServiceRemote {
	public User getEmployeByEmailAndPassword(String login, String password);
}
