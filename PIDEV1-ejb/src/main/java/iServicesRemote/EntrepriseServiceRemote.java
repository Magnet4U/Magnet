package iServicesRemote;

import javax.ejb.Remote;

import entites.Entreprise;

@Remote
public interface EntrepriseServiceRemote {
	public void ajouterEntreprise(Entreprise p);
}
